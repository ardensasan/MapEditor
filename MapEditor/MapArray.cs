using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    class MapArray
    {
        public int[,] GenerateMapArray(int xDimension,int yDimension)
        {
            int x, y;
            int[,] mapArray = new int[xDimension, yDimension];
            for(x = 0;x< xDimension; x++)
            {
                for(y = 0; y < yDimension; y++)
                {
                    mapArray[x, y] = 0;
                }
            }
            return mapArray;
        }
    }
}
