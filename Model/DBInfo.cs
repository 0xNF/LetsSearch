using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;
using System.Diagnostics;
using Windows.ApplicationModel;
using System.IO;
using System.Threading.Tasks;
using JDictU.Model;
using Windows.UI.Xaml;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
//using System.Data.


namespace JDictU.Model
{


    public class DBInfo {
        private const string jayDict = "model\\JayDictFIXED4.db";
        private const string userdata = "model\\userdata.db";
        private const string kradfile = "model\\kradfile-u.txt";
        private const string kanji = "model\\kanji.sqlite";
        public static SQLiteAsyncConnection JconnAsync = null; //SQlite connect to Jaydict, filled in later
        public static SQLiteAsyncConnection UconnAsync = null;
        public static SQLiteAsyncConnection KconnAsync = null;




        //This function runs once every startup but only does the work when the app is started for the very first time. Copies from InstalledLocation into LocalFolder
        //Perhaps the single most important function in the entire system - note when moving to other platforms, this thing must be present in one form or another. 
        static private async Task CopyDatabase(string file, StorageFolder loc) {
            string culledFile = file.Substring(6);
            Debug.WriteLine("Checking for Existence of " + culledFile);
            try {
                StorageFile storageFile = await loc.GetFileAsync(culledFile);
            }
            catch(System.IO.FileNotFoundException fnf) {
                Debug.WriteLine("Existence was false, loading the DB");
                StorageFolder installed = Package.Current.InstalledLocation;
                StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync(file); //this one stays the same, because we need to move it from Model\\whatever.db
                try {
                    await databaseFile.CopyAsync(loc, culledFile, NameCollisionOption.FailIfExists);
                }
                catch(Exception e) {
                    Debug.WriteLine("Already existed, everything is OK");
                }
            }
            catch(System.Exception e) {
                Debug.WriteLine("Error loading...");
                Debug.WriteLine(e);
            }
        }

        //Use this to delete corrupted database fiels from the IsolatedStorage - useful in testing
        static public async Task delete(string file) {
            Debug.WriteLine("Deleting the File from isostore");
            StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync(file);
            await storageFile.DeleteAsync();
            Debug.WriteLine("...Done!");
        }

        //Methods
        //assigns Jaydict to conn
        //This sets the class variable AND returns its handle - necessary or redundant?
        static async public void getJayDictAsync() {
            await CopyDatabase(jayDict, ApplicationData.Current.LocalFolder);
            if (JconnAsync == null) {
                var conFunction = new Func<SQLiteConnectionWithLock>(() =>
                    new SQLiteConnectionWithLock(new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(jayDict, false)));

                var connectionString = new SQLiteConnectionString(jayDict, false);
                var connectionWithLock = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), connectionString);
                JconnAsync = new SQLiteAsyncConnection(() => connectionWithLock);
            }
        }

        static async public void getKanjiAsync() {
            await CopyDatabase(kanji, ApplicationData.Current.LocalFolder);
            if (KconnAsync == null) {
                var conFunction = new Func<SQLiteConnectionWithLock>(() =>
                    new SQLiteConnectionWithLock(new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(kanji, false)));

                var connectionString = new SQLiteConnectionString(kanji, false);
                var connectionWithLock = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), connectionString);
                KconnAsync = new SQLiteAsyncConnection(() => connectionWithLock);
            }
        }

        static async public void getKradfileAsync() {
            await CopyDatabase(kradfile, ApplicationData.Current.LocalFolder);
        }

        static async public void getUserDataAsync() {
            await CopyDatabase(userdata, ApplicationData.Current.RoamingFolder);
            if (UconnAsync == null) {
                var conFunction = new Func<SQLiteConnectionWithLock>(() =>
                    new SQLiteConnectionWithLock(new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(ApplicationData.Current.RoamingFolder.Path +"\\userdata.db", false)));
                var connectionString = new SQLiteConnectionString(ApplicationData.Current.RoamingFolder.Path + "\\userdata.db", false);
                var connectionWithLock = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), connectionString);
                UconnAsync = new SQLiteAsyncConnection(() => connectionWithLock);
            }
        }
    }

}
