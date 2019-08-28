using System.Collections.Generic;
using System.Drawing;
using System.IO;

public class Bitmaps {
    public List<Bitmap> goldList;
    public List<Bitmap> expList;
    public List<Bitmap> championList;
    public Bitmap planning;
    public Bitmap item;
    public Bitmap gold;
    public Bitmap hp;

    public Bitmaps() {
        goldList = new List<Bitmap>();
        expList = new List<Bitmap>();
        championList = new List<Bitmap>();

        Load(goldList, @"Sprites\Gold", true);
        Load(expList, @"Sprites\Exp", true);
        Load(championList, @"Sprites\Champions");

        planning = new Bitmap(@"Sprites\Others\Planning.png");
        item = new Bitmap(@"Sprites\Others\Item.png");
        gold = new Bitmap(@"Sprites\Others\Gold.png");
        hp = new Bitmap(@"Sprites\Others\Hp.png");
    }

    private void Load(List<Bitmap> list, string path, bool numericSort = false) {
        DirectoryInfo dir = new DirectoryInfo(path);
        List<string> s = new List<string>();
        foreach (var file in dir.GetFiles("*.png")) {
            s.Add(file.FullName);
        }

        if (numericSort)
            s.Sort(delegate (string x, string y) {
                if (int.Parse(Path.GetFileNameWithoutExtension(x)) < int.Parse(Path.GetFileNameWithoutExtension(y)))
                    return -1;
                else
                    return +1;
            }
            );

        foreach (var file in s) {
            list.Add(new Bitmap(file));
        }

    }
}