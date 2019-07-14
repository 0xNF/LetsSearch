import sqlite3

jdf4 = sqlite3.connect("./JayDictFIXED4.db")

def collectIds():
    tups = []
    tids = []
    q = "SELECT entry_id, kanji, kana_map FROM super;"
    for row in jdf4.execute(q):
        i = row[0]
        if row[1] == None or len(row[1]) != 0:
            s = row[1].split('|')[0]
        else:
            r2 = row[2]
            if '|' in r2:
                s = r2.split('|')[0].split(':')[0]
            else:
                s = r2.split(':')[0]
        tids.append((i, s))
    return tids

def collectEcounts(tids):
    q2 = "SELECT COUNT(*), SUM(verified) FROM headwords AS H JOIN sentences AS S ON H.sentenceid=S.id WHERE H.headword IS ?;"
    tups = []
    for tid in tids:
        t = 0
        v = 0
        t1 = tid[1]
        for row in jdf4.cursor().execute(q2, (t1,)):
            t = row[0]
            if row[1] is None:
                v = 0
            else:
                v = row[1]
        tups.append((t, v, tid[0]))
    return tups

def updateECounts(tups):
    q = "UPDATE super SET example_total=?, example_verified=? WHERE entry_id=?;"
    jdf4.executemany(q, tups)
    jdf4.commit()


def main():
    tids = collectIds()
    eCounts = collectEcounts(tids)
    updateECounts(eCounts)


if __name__ == "__main__":
    main()