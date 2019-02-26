using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; private set; }
        public int Defense { get; private set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Golds { get; set; }
        public Weapon EquippedWeapon { get; private set; }
        public Armor EquippedArmor { get; private set; }
        public Shield EquippedShield { get; private set; }
        public List<Weapon> WeaponsBag { get; set; }
        public List<Armor> ArmorsBag { get; set; }
        public List<Shield> ShieldsBag { get; set; }
        public List<Potion> PotionsBag { get; set; }

        public Hero()
        {
            ArmorsBag = new List<Armor>();
            WeaponsBag = new List<Weapon>();
            ShieldsBag = new List<Shield>();
            PotionsBag = new List<Potion>();
            Strength = 10;
            Defense = 10;
            OriginalHP = 30;
            CurrentHP = 30;
            Golds = 20;//initial golds provided for testing the shop functionality
        }

        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.WriteLine("*****" + this.Name + "*****");

            if (this.EquippedWeapon != null)
            {
                Console.WriteLine("Strength: " + this.Strength + "(+" + this.EquippedWeapon.Strength + ")");
            }
            else
            {
                Console.WriteLine("Strength: " + this.Strength);
            }

            if (this.EquippedArmor != null && this.EquippedShield != null)
            {

                Console.WriteLine("Defense: " + this.Defense + "(+" + (this.EquippedArmor.Defense + this.EquippedShield.Defense) + ")");
            }
            else if (this.EquippedArmor != null && this.EquippedShield == null)
            {
                Console.WriteLine("Defense: " + this.Defense + "(+" + this.EquippedArmor.Defense + ")");
            }
            else if (this.EquippedArmor == null && this.EquippedShield != null)
            {
                Console.WriteLine("Defense: " + this.Defense + "(+" + this.EquippedShield.Defense + ")");
            }
            else
            {
                Console.WriteLine("Defense: " + this.Defense);
            }


            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");

            foreach (var weapon in this.WeaponsBag)
            {
                Console.WriteLine(weapon.Name + " of " + weapon.Strength + " Strength");
            }

            Console.WriteLine("Armors: ");

            foreach (var armor in this.ArmorsBag)
            {
                Console.WriteLine(armor.Name + " of " + armor.Defense + " Defense");
            }


            Console.WriteLine("Shields: ");

            foreach (var shield in this.ShieldsBag)
            {
                Console.WriteLine(shield.Name + " of " + shield.Defense + " Defense");
            }

            Console.WriteLine("Potions: ");

            foreach (var potion in this.PotionsBag)
            {
                Console.WriteLine(potion.Name + " of " + potion.HealthRestored + " Health Restored");
            }
            Console.WriteLine("Golds: " + Golds);
        }

        public void EquipWeapon()
        {
            if (!WeaponsBag.Any())
            {
                Console.WriteLine("Sorry. No weapon to equip!!!");
            }
            else
            {
                var weaponsID = "";
                Console.Write("Please type weapon's ID: ");
                weaponsID = Console.ReadLine();

                foreach (var weapon in this.WeaponsBag)
                {
                    if (weapon.ID.ToLower() == weaponsID.ToLower() && weapon.Equipped == true)
                    {
                        Console.WriteLine("Weapon already equipped!!!");
                    }
                    else if (weapon.ID.ToLower() == weaponsID.ToLower() && weapon.Equipped == false)
                    {
                        this.EquippedWeapon = weapon;
                        weapon.Equipped = true;
                        Console.WriteLine("Successfully equipped weapon!!!");
                    }
                }
            }
        }

        public void EquipArmor()
        {
            if (!ArmorsBag.Any())
            {
                Console.WriteLine("Sorry. No armor to equip!!!");
            }
            else
            {
                var armorsID = "";
                Console.Write("Please type armor's ID: ");
                armorsID = Console.ReadLine();

                foreach (var armor in this.ArmorsBag)
                {
                    if (armor.ID.ToLower() == armorsID.ToLower() && armor.Equipped == true)
                    {
                        Console.WriteLine("Armor already equipped!!!");
                    }
                    else if (armor.ID.ToLower() == armorsID.ToLower() && armor.Equipped == false)
                    {
                        this.EquippedArmor = armor;
                        armor.Equipped = true;
                        Console.WriteLine("Successfully equipped armor!!!");
                    }
                }
            }
        }

        public void EquipShield()
        {
            if (!ShieldsBag.Any())
            {
                Console.WriteLine("Sorry. No shield to equip!!!");
            }
            else
            {
                var shieldID = "";
                Console.Write("Please type shields's ID: ");
                shieldID = Console.ReadLine();

                foreach (var shield in this.ShieldsBag)
                {
                    if (shield.ID.ToLower() == shieldID.ToLower() && shield.Equipped == true)
                    {
                        Console.WriteLine("Shield already equipped!!!");
                    }
                    else if (shield.ID.ToLower() == shieldID.ToLower() && shield.Equipped == false)
                    {
                        this.EquippedShield = shield;
                        shield.Equipped = true;
                        Console.WriteLine("Successfully equipped shield!!!");
                    }
                }
            }
        }

        public void UnequipWeapon()
        {
            if (this.EquippedWeapon == null)
            {
                Console.WriteLine("Sorry you are not equipped with any weapon!!!");
            }
            else
            {
                this.EquippedWeapon = null;
                foreach (var weapon in this.WeaponsBag)
                {
                    weapon.Equipped = false;
                }
                Console.WriteLine("Weapon successfully unequiped!!!");
            }
        }

        public void UnequipArmor()
        {
            if (this.EquippedArmor == null)
            {
                Console.WriteLine("Sorry you are not equipped with any armor!!!");
            }
            else
            {
                this.EquippedArmor = null;
                foreach (var armor in this.ArmorsBag)
                {
                    armor.Equipped = false;
                }
                Console.WriteLine("Armor successfully unequiped!!!");
            }
        }

        public void UnequipShield()
        {
            if (this.EquippedShield == null)
            {
                Console.WriteLine("Sorry you are not equipped with any shield!!!");
            }
            else
            {
                this.EquippedShield = null;
                foreach (var shield in this.ShieldsBag)
                {
                    shield.Equipped = false;
                }
                Console.WriteLine("Shield successfully unequiped!!!");
            }
        }

        public void PurchaseWeapon(Weapon weapon)
        {
            if (weapon == null)
            {
                Console.WriteLine($"Sorry. weapon not found!!!");
            }
            else if (this.Golds < weapon.Price)
            {
                Console.WriteLine($"Sorry. Not enough Golds!!!");
            }
            else
            {
                this.Golds -= weapon.Price;
                Console.WriteLine($"{weapon.Name} successfully purchased!!!");
                WeaponsBag.Add(weapon);
            }

        }

        public void PurchaseArmor(Armor armor)
        {
            if (armor == null)
            {
                Console.WriteLine($"Sorry. armor not found!!!");
            }
            else if (this.Golds < armor.Price)
            {
                Console.WriteLine($"Sorry. Not enough Golds!!!");
            }
            else
            {
                this.Golds -= armor.Price;
                Console.WriteLine($"{armor.Name} successfully purchased!!!");
                ArmorsBag.Add(armor);
            }
        }

        public void PurchaseShield(Shield shield)
        {
            if (shield == null)
            {
                Console.WriteLine($"Sorry. Shield not found!!!");
            }
            else if (this.Golds < shield.Price)
            {
                Console.WriteLine($"Sorry. Not enough Golds!!!");
            }
            else
            {
                this.Golds -= shield.Price;
                Console.WriteLine($"{shield.Name} successfully purchased!!!");
                ShieldsBag.Add(shield);
            }
        }

        public void PurchasePotion(Potion potion)
        {
            if (potion == null)
            {
                Console.WriteLine($"Sorry. Potion not found!!!");
            }
            else if (this.Golds < potion.Price)
            {
                Console.WriteLine($"Sorry. Not enough Golds!!!");
            }
            else
            {
                this.Golds -= potion.Price;
                Console.WriteLine($"{potion.Name} successfully purchased!!!");
                PotionsBag.Add(potion);
            }
        }

        public void Heal(Potion potion)
        {
            if (potion == null)
            {
                Console.WriteLine("Sorry. Potion not found!!!");
            }
            else
            {
                if (potion.HealthRestored + this.CurrentHP > this.OriginalHP)
                {
                    this.CurrentHP = this.OriginalHP;
                }
                else
                {
                    this.CurrentHP += potion.HealthRestored;
                }
                this.PotionsBag.Remove(potion);
                Console.WriteLine("Health potion successfully used!!!");
            }
        }

        public void UsePotion()
        {
            var maxHP = this.OriginalHP;

            if (this.CurrentHP == maxHP)
            {
                Console.WriteLine("No need to heal. HP is full");
            }
            else if (!this.PotionsBag.Any())
            {
                Console.WriteLine("Sorry. You don't have any healing potion!");
            }
            else
            {
                Console.WriteLine("Choose a potion to use:");

                foreach (var potion in this.PotionsBag)
                {
                    Console.WriteLine(potion.DisplayInfo());
                }

                Console.Write("Please type the potion id to use: ");

                var potionInput = Console.ReadLine();
                Potion potionToUse = null;

                foreach (var potion in this.PotionsBag.ToList())
                {
                    if (potion.ID.ToLower() == potionInput)
                    {
                        potionToUse = potion;
                    }
                }
                this.Heal(potionToUse);
            }
        }
    }
}