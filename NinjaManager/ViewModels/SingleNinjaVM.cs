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
            HeadEquipment = GenerateText(Ninja.Gear.Where(x => x.Category == Category.Head).FirstOrDefault());
            ShoulderEquipment = GenerateText(Ninja.Gear.Where(x => x.Category == Category.Shoulders).FirstOrDefault());
            ChestEquipment = GenerateText(Ninja.Gear.Where(x => x.Category == Category.Chest).FirstOrDefault());
            BeltEquipment = GenerateText(Ninja.Gear.Where(x => x.Category == Category.Belt).FirstOrDefault());
            BootsEquipment = GenerateText(Ninja.Gear.Where(x => x.Category == Category.Boots).FirstOrDefault());
            PantsEquipment = GenerateText(Ninja.Gear.Where(x => x.Category == Category.Legs).FirstOrDefault());
        }

        private string GenerateText(Gear gear)
        {
            return gear == null ? "No gear\nequipped!" : $"Agility: {gear.Agility}\n" +
                $"Strength: {gear.Strength}\n" +
                $"Intelligence: {gear.Intelligence}";
        }
    }
}
