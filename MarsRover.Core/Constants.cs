namespace MarsRover.Core
{
    internal static class Constants
    {
        public const int XMax = 5;
        public const int YMax = 5;
        public const int XMin = 0;
        public const int YMin = 0;

        public const string OutOfGridErrorMessage = "Steps are incorrect: rover is sent out of grid!";
        public const string CellIsOccupiedErrorMessage = "The cell is occupied by another rover! Select another route.";
        public const string InvalidInputErrorMessage = "Invalid input. Two or more rovers are trying to be deployed on the same cell.";
    }
}
