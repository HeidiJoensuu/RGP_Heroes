using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBG_Heroes.Attributes
{
    /// <summary>
    /// HeroAttributes class
    /// </summary>
    public class HeroAttributes
    {
        private int strength;
        private int dexterity;
        private int intelligence;


        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }

        /// <summary>
        /// Initializes a new instanse of the <see cref="HeroAttributes" /> class.
        /// </summary>
        /// <param name="strength"> <see cref="int"/></param>
        /// <param name="dexterity">  <see cref="int"/></param>
        /// <param name="intelligence">  <see cref="int"/></param>
        public HeroAttributes(int strength, int dexterity, int intelligence)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
        }


        /// <summary>
        /// Increases heroAttributes by given numbers.
        /// </summary>
        /// <param name="strength">  <see cref="int"/> Strength to be encreased </param>
        /// <param name="dexterity">  <see cref="int"/> Dexterity to be encreased</param>
        /// <param name="intelligence">  <see cref="int"/> Intelligence to be encreased</param>
        public void IncreaseAttributes(int strength, int dexterity, int intelligence)
        {
            this.strength += strength;
            this.dexterity += dexterity;
            this.intelligence += intelligence;
        }
    }
}
