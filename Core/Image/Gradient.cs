using System;
using System.Collections.Generic;

namespace Core.Image
{
    public class Gradient
    {
        private List<Byte[]> colors;
        private float ratio;
        
        public Gradient(List<byte[]> colors)
        {
            this.colors = colors;
            this.ratio = (float) 1 / (colors.Count - 1);
        }
        
        public byte[] Tween(float amount)
        {
            amount %= 1;
            
            int index = (int) System.Math.Floor(amount / ratio);
            int upperIndex = index + 1;


            float scaled = amount % ratio;
            float scalar = scaled / this.ratio;

            byte R = (byte) (colors[index][0] + ((colors[upperIndex][0] - colors[index][0]) * scalar));
            byte G = (byte) (colors[index][1] + ((colors[upperIndex][1] - colors[index][1]) * scalar));
            byte B = (byte) (colors[index][2] + ((colors[upperIndex][2] - colors[index][2]) * scalar));
            
            
            return new byte[3] {R, G, B};
        }
    }
}