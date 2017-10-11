using System;
using System.Collections.Generic;

namespace Core.Image
{
    /// <summary>
    /// Class to handle tweening between any number of Colours to give a Gradient effect
    /// </summary>
    public class Gradient
    {
        /// <summary>
        /// The list of Colors to tween between
        /// </summary>
        private readonly Color[] colors;
        
        /// <summary>
        /// The ratio between 0-1 and the number of Colours
        /// </summary>
        private readonly float ratio;
        
        public Gradient(Color[] colors)
        {
            if (colors.Length <= 1)
            {
                throw new Exception("Cannot create Gradient with fewer than 2 Colours");
            }
            
            this.colors = colors;
            this.ratio = (float) 1 / (colors.Length - 1);
        }
        
        /// <summary>
        /// Gets a Colour based on the tweening percentage (0-1).
        /// Value wraps around to the beginning if a value greater than 1 is supplied
        /// </summary>
        /// <param name="percentage">The percentage through the Tween to get a Color from</param>
        /// <returns>The tweened Colour</returns>
        public Color Tween(float percentage)
        {
            // Wrap it around to 0-1
            percentage %= 1;
            
            // Figure out what Colours are being tweened between
            int index = (int) System.Math.Floor(percentage / ratio);
            int upperIndex = index + 1;

            // Wrap the 0-1 percentage to a step between the two colours
            float scaled = percentage % ratio;
            // Convert the wrapped value back to a 0-1 range
            float scalar = scaled / this.ratio;

            // Get all the colour values from the base colour plus the scaled amount of the second colour
            byte R = (byte) (colors[index].R + ((colors[upperIndex].R - colors[index].R) * scalar));
            byte G = (byte) (colors[index].G + ((colors[upperIndex].G - colors[index].G) * scalar));
            byte B = (byte) (colors[index].B + ((colors[upperIndex].B - colors[index].B) * scalar));
            
            // Return as colour
            return new Color(R, G, B);
        }
    }
}