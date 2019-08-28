using AutoIt;

public static class Pickupable {

    public static void PickupAll() {
        int xMin = 450, xMax = 1450, yMin = 250, yMax = 700;
        int steps = 5;
        int move = (yMax - yMin) / steps;

        for (int i = 0; i < steps + 1; i++) {

            AutoItX.MouseClick("LEFT", xMin, yMin + move * i, 1, 15);
            AutoItX.Sleep(1000);
            AutoItX.MouseClick("LEFT", xMax, yMin + move * i, 1, 15);
            AutoItX.Sleep(1000);
        }

    }
}