using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Models;
namespace NinjaManager.ViewModels
{
    public class SingleNinjaVM : BaseVM
    {
        public string Saus { get; set; }
        public Ninja Ninja { get; set; }

        public string HeadEquipment { get; set; }
        public string ShoulderEquipment { get; set; }
        public string ChestEquipment { get; set; }
        public string BeltEquipment { get; set; }
        public string BootsEquipment { get; set; }
        public string PantsEquipment { get; set; }

        public SingleNinjaVM(Ninja ninja)
        {
            Ninja = ninja;
            HeadEquipment = GenerateText(Ninja.Gear.FirstOrDefault(x => x.Category == Category.Head));
            ShoulderEquipment = GenerateText(Ninja.Gear.FirstOrDefault(x => x.Category == Category.Shoulders));
            ChestEquipment = GenerateText(Ninja.Gear.FirstOrDefault(x => x.Category == Category.Chest));
            BeltEquipment = GenerateText(Ninja.Gear.FirstOrDefault(x => x.Category == Category.Belt));
            BootsEquipment = GenerateText(Ninja.Gear.FirstOrDefault(x => x.Category == Category.Boots));
            PantsEquipment = GenerateText(Ninja.Gear.FirstOrDefault(x => x.Category == Category.Legs));
        }

        private string GenerateText(Gear gear)
        {
            return gear == null ? "No gear\nequipped!" : 
                $"{gear.Name}\n" +
                $"Agility: {gear.Agility}\n" +
                $"Strength: {gear.Strength}\n" +
                $"Intelligence: {gear.Intelligence}";
        }
    }
}
