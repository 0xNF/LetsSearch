using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite.Net;

namespace JDictU.Model {
    public class UserData {


        public static async Task insertIntoSearchHistory(string searchQuery) {

            long ticks = DateTime.UtcNow.Ticks;
            try {
                History H = new History {
                    search_query = searchQuery,
                    search_date = ticks
                };
                await DBInfo.UconnAsync.InsertAsync(H);
            }
            catch (NotSupportedException sle) {
                Debug.WriteLine(sle);
            }



        }

        public static async Task deleteItemFromSearchHistory(int id) {
            try {
                await DBInfo.UconnAsync.ExecuteAsync("delete * from history where id is " + id);
            }
            catch (SQLiteException sle) {
                Debug.WriteLine(sle);
            }
        }

        public static async Task clearHistory() {
            try {
                await DBInfo.UconnAsync.ExecuteAsync("delete from history");
            }
            catch (SQLiteException sle) {
                Debug.WriteLine(sle);
            }
        }

        public static async Task clearFavorites() {
            try {
                await DBInfo.UconnAsync.ExecuteAsync("delete from favorites");
            }
            catch (SQLiteException sle) {
                Debug.WriteLine(sle);
            }
        }

        /** retrieves all records from the Favorites table of UserData.sqlite**/
        public static async Task<List<Favorites>> retrieveFavorite() {
            List<Favorites> retFavs = await DBInfo.UconnAsync.QueryAsync<Favorites>("select * from favorites order by entry_id asc");
            return retFavs;
        }

        /** inserts a new favorites into the Favorites table of UserData.sqlite **/
        public static async void insertIntoFavorites(int entryID, string display) {
            try {
                Debug.WriteLine("Favoriting " + entryID);
                Favorites f = new Favorites {
                    entry_id = entryID,
                    display_string = display
                };
                await DBInfo.UconnAsync.InsertAsync(f);
            }
            catch (SQLiteException sle) {
                Debug.WriteLine(sle);
            }
        }

        /** removes a favorite from the Favorites table of UserData.sqlite **/
        public static async void removeFromFavorites(int entryID) {
            try {
                await DBInfo.UconnAsync.DeleteAsync<Favorites>(entryID);
            }
            catch (SQLiteException sle) {
                Debug.WriteLine(sle);
            }
        }

        /** Checks if a given entry ID is favorited **/
        public static bool isFavorited(int entryID) {
            try {
                //    var x= await DBInfo.UconnAsync.QueryAsync<Favorites>("select * from favorites where entry_id is ?", entryID));
                //    return x.Count > 0;
                var x = Task.Run(() => DBInfo.UconnAsync.QueryAsync<Favorites>("select entry_id from favorites where entry_id is ?", entryID));
                x.Wait();
                return x.Result.Count > 0;
            }
            catch (SQLiteException sle) {
                Debug.WriteLine(sle);
                return false;
            }
        }

        /** Retrieves records from Search **/
        public static async Task<List<History>> retrieveSearchHistory(string order, string dir) {
            //TryCatch take splace at location of method call
            List<History> retSearch = await DBInfo.UconnAsync.QueryAsync<History>("select * from history order by " + order + " " + dir);
            return retSearch;
        }
    }
}
