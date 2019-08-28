using System.Drawing;
using System;

public static class Board {
    public static Champion[] board = new Champion[30];

    public static Point GetPosition(int index) {
        Point p;
        if(index < 9) {
            p = new Point(1 * index, 1);
        } else if (index < 16) {
            index -= 9;
            p = new Point(1 * index, 1);
        } else if (index < 23) {
            index -= 16;
            p = new Point(1 * index, 1);
        } else {
            index -= 23;
            p = new Point(1 * index, 1);
        }

        return p;
    }

    public static float GetValue(ChampionName name) {
        Champion[] arr = Array.FindAll(board, x => x.name == name);
        float count = 0;
        foreach(var c in arr) {
            count += c.level;
        }
        switch(count) {
        case 1:
            count = 10;
            break;
        case 2:
            count = 20;
            break;
        case 3:
            count = 50;
            break;
        case 4:
            count = 10;
            break;
        case 5:
            count = 30;
            break;
        case 6:
            count = 40;
            break;
        case 7:
            count = 20;
            break;
        case 8:
            count = 40;
            break;
        case 9:
            count = 500;
            break;
        case 10:
            count = -50;
            break;
        }
        
        return count;
    }
}
