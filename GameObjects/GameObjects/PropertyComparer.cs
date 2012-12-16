namespace GameObjects
{
    using GameGlobal;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class PropertyComparer : IComparer<GameObject>
    {
        private bool isNumber;
        private string propertyName;
        private bool SmallToBig;

        public PropertyComparer(string propertyName, bool isNumber, bool SmallToBig)
        {
            this.propertyName = propertyName;
            this.isNumber = isNumber;
            this.SmallToBig = SmallToBig;
        }

        private static Regex dateMatcher = new Regex("^(\\d+)年(1?\\d)月([123]?\\d)日$", RegexOptions.Compiled);
        private static Regex slashMatcher = new Regex("^(\\d+)/(\\d+)$", RegexOptions.Compiled);
        public int Compare(GameObject x, GameObject y)
        {
            if ((x == null) || (y == null))
            {
                return 0;
            }

            int result = 0;

            if (this.isNumber)
            {
                try
                {
                    long longResult = ((long)(int)StaticMethods.GetPropertyValue(x, this.propertyName)) - ((long)(int)StaticMethods.GetPropertyValue(y, this.propertyName));
                    if (longResult > 0)
                    {
                        result = 1;
                    }
                    else if (longResult < 0)
                    {
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
                }
                catch (InvalidCastException)
                {
                    try
                    {
                        if (Math.Abs((double)StaticMethods.GetPropertyValue(x, this.propertyName) - (double)StaticMethods.GetPropertyValue(y, this.propertyName)) < 0.00001) return 0;
                        result = (((double)StaticMethods.GetPropertyValue(x, this.propertyName)) > ((double)StaticMethods.GetPropertyValue(y, this.propertyName))) ? 1 : -1;
                    }
                    catch (InvalidCastException)
                    {
                        result = -1;
                    }
                }
            }
            else
            {
                String xStr = StaticMethods.GetPropertyValue(x, this.propertyName).ToString();
                String yStr = StaticMethods.GetPropertyValue(y, this.propertyName).ToString();
                Match xMatch = slashMatcher.Match(xStr);
                Match yMatch = slashMatcher.Match(yStr);

                if (xMatch.Success && yMatch.Success)
                {
                    int xLeft = int.Parse(xMatch.Groups[1].ToString());
                    int xRight = int.Parse(xMatch.Groups[2].ToString());
                    int yLeft = int.Parse(yMatch.Groups[1].ToString());
                    int yRight = int.Parse(yMatch.Groups[2].ToString());
                    result = xRight == yRight ? xLeft - yLeft : xRight - yRight;
                }
                else
                {
                    xMatch = dateMatcher.Match(xStr);
                    yMatch = dateMatcher.Match(yStr);
                    if (xMatch.Success && yMatch.Success)
                    {
                        int xYear = int.Parse(xMatch.Groups[1].ToString());
                        int xMonth = int.Parse(xMatch.Groups[2].ToString());
                        int xDay = int.Parse(xMatch.Groups[3].ToString());
                        int yYear = int.Parse(yMatch.Groups[1].ToString());
                        int yMonth = int.Parse(yMatch.Groups[2].ToString());
                        int yDay = int.Parse(yMatch.Groups[3].ToString());
                        if (xYear == yYear)
                        {
                            if (xMonth == yMonth)
                            {
                                result = xDay - yDay;
                            }
                            else
                            {
                                result = xMonth - yMonth;
                            }
                        }
                        else
                        {
                            result = xYear - yYear;
                        }
                    }
                    else
                    {
                        result = xStr.CompareTo(yStr);
                    }
                }
            }

            if (!this.SmallToBig)
            {
                result = -result;
            }

            return result;
        }
    }
}

