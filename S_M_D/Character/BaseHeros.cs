using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S_M_D.Spell;
using S_M_D.Camp;


namespace S_M_D.Character
{
    [Serializable]
    public abstract class BaseHeros : BaseCharacter
    {
        readonly string _characterClassName;
        readonly GameContext _ctx;
        int _price;
        bool _isMale;
        int _evilness;
        readonly Spells[] _spells;
        readonly List<Sickness> _sicknesses;
        readonly List<Psychology> _psycho;
        readonly List<Relationship> _relationship;
        string _owner;
        BaseBuilding _inBuilding;
        BaseItem[] _equipement;
        int _xp;
        int _xpMax;

        public BaseHeros( GameContext ctx, string characterClassName, int price, bool isMale, int evilness, string sickness, string psycho, string relation, BaseItem[] equipement, int xp, int xpMax,
            string characterName, int lvl, int hpMax, int manaMax, int damage, int critChance, int hitChance, int speed, int affectRes, int bleedingRes, int magicRes, int fireRes, 
            int poisonRes, int waterRes, int defense, int dodgeChance, Spells[] spells)
        {
            _characterClassName = characterClassName;
            _ctx = ctx;
            _price = price;
            _isMale = isMale;
            _evilness = evilness;
            _xp = xp;
            _xpMax = xpMax;
            AffectRes = affectRes;
            BleedingRes = bleedingRes;
            CharacterName = characterName;
            CritChance = critChance;
            Damage = damage;
            Defense = defense;
            DodgeChance = dodgeChance;
            FireRes = fireRes;
            HitChance = hitChance;
            HP = hpMax;
            HPmax = hpMax;
            Lvl = lvl;
            MagicRes = magicRes;
            Mana = manaMax;
            ManaMax = manaMax;
            PoisonRes = poisonRes;
            Speed = speed;
            WaterRes = waterRes;
            _inBuilding = null;
            _spells = new Spells[8];
            Equipement = new BaseItem[4];
            _sicknesses = new List<Sickness>();
            _psycho = new List<Psychology>();
            _relationship = new List<Relationship>();
            IsDead = false;
        }
        /// <summary>
        /// Put a new item if the item slot wasn't empty return exeption 
        /// </summary>
        /// <param name="itemToAdd">Item to add</param>
        public void GetNewItem (BaseItem itemToAdd)
        {
            if (itemToAdd.Itemtype == BaseItem.ItemTypes.Armor)
            {
                if (Equipement[0] == null)
                {
                    Equipement[0] = itemToAdd;
                    _ctx.PlayerInfo.MyItems.Remove( itemToAdd );
                }
                else throw new ArgumentException( "You already have an armor!" );
            }
            else if (itemToAdd.Itemtype == BaseItem.ItemTypes.Weapon)
            {
                if (Equipement[1] == null)
                {
                    Equipement[1] = itemToAdd;
                    _ctx.PlayerInfo.MyItems.Remove( itemToAdd );
                }
                else throw new ArgumentException( "You already have a weapon!" );
            }
            else if (itemToAdd.Itemtype == BaseItem.ItemTypes.Trinket)
            {
                if (Equipement[2] == null)
                {
                    Equipement[2] = itemToAdd;
                    _ctx.PlayerInfo.MyItems.Remove( itemToAdd );
                }
                else if (Equipement[3] == null)
                {
                    Equipement[3] = itemToAdd;
                    _ctx.PlayerInfo.MyItems.Remove( itemToAdd );
                }
                else throw new ArgumentException( "You already have a Trinket!" );
            }
            else throw new ArgumentException( "Type of item non reconize!" );
            UpdateHeroStats();
        }
        /// <summary>
        /// Remove an item from an hero and add an item from inventory
        /// </summary>
        /// <param name="itemToRemove">Item from the Hero</param>
        /// <param name="itemToAdd">Item from the inventory</param>
        public void RemoveAndAddAnItem(BaseItem itemToRemove, BaseItem itemToAdd)
        {
            int x = 0;
            foreach (BaseItem equip in Equipement)
            {
                if (equip == itemToRemove && itemToRemove.Itemtype == itemToAdd.Itemtype)
                {
                    _ctx.PlayerInfo.MyItems.Remove( itemToAdd );
                    _ctx.PlayerInfo.MyItems.Add( itemToRemove );
                    Equipement[x] = itemToAdd;
                    UpdateHeroStats();
                }
                x++;
            }
        }
        /// <summary>
        /// Add hero from deadhero list
        /// </summary>
        public void Die()
        {
            _ctx.PlayerInfo.DeadHero.Add( this );
            _ctx.PlayerInfo.MyHeros.Remove( this );
        }

        /// <summary>
        /// Remove item from a hero
        /// </summary>
        /// <param name="item">Item to remove</param>
        public void RemoveItem(BaseItem item)
        {

            int x = 0;
            foreach (BaseItem equip in Equipement)
            {
                if (equip == item)
                {
                    Equipement[x] = null;
                    _ctx.PlayerInfo.MyItems.Add( item );
                    UpdateHeroStats();
                }
                x++;
            }
        }
        /// <summary>
        /// Add Stats from Item
        /// </summary>
        /// <param name="item"></param>
        public void AddItemStats(BaseItem item)
        {
            EffectivHPMax += item.HP;
            HP += item.HP;
            if (EffectivHPMax <= 1) EffectivHPMax = 1;
            EffectivManaMax += item.Mana;
            Mana += item.Mana;
            if (EffectivManaMax <= 1) EffectivManaMax = 1;
            EffectCritChance += item.CritChance;
            if (EffectCritChance <= 0) EffectCritChance = 0;
            EffectivAffectRes += item.AffectRes;
            if (EffectivAffectRes <= 0) EffectivAffectRes = 0;
            EffectivBleedingRes += item.BleedingRes;
            if (EffectivBleedingRes <= 0) EffectivBleedingRes = 0;
            EffectivDamage += item.Damage;
            if (EffectivDamage <= 0) EffectivDamage = 0;
            EffectivDefense += item.Defense;
            if (EffectivDefense <= 0) EffectivDefense = 0;
            EffectivDodgeChance += item.DodgeChance;
            if (EffectivDodgeChance <= 0) EffectivDodgeChance = 0;
            EffectivFireRes += item.FireRes;
            if (EffectivFireRes <= 0) EffectivFireRes = 0;
            EffectivHitChance += item.HitChance;
            if (EffectivHitChance <= 0) EffectivHitChance = 0;
            EffectivMagicRes += item.MagicRes;
            if (EffectivMagicRes <= 0) EffectivMagicRes = 0;
            EffectivPoisonRes += item.PoisonRes;
            if (EffectivPoisonRes <= 0) EffectivPoisonRes = 0;
            EffectivSpeed += item.Speed;
            if (EffectivSpeed <= 0) EffectivSpeed = 0;
            EffectivWaterRes += item.WaterRes;
            if (EffectivWaterRes <= 0) EffectivWaterRes = 0;
        }
        /// <summary>
        /// Add a relation ship to an hero
        /// </summary>
        /// <param name="relation">The relation to add</param>
        /// <exception cref="ArgumentException"> Can't add a relation if the two hero of the relation are alredy relation </exception>
        public void GetRelationship(Relationship relation)
        {
            BaseHeros heros1 = relation.HeroDuo[0];
            BaseHeros heros2 = relation.HeroDuo[1];

            foreach (Relationship relations in _relationship)
            {
                if (heros1 == relations.HeroDuo[0] && heros2 == relations.HeroDuo[1]) throw new ArgumentException("dude, they cant have two relation at the same time");
                if (heros1 == relations.HeroDuo[1] && heros2 == relations.HeroDuo[0]) throw new ArgumentException("dude, they cant have two relation at the same time"); 
            }

            _relationship.Add(relation);
            UpdateHeroStats();
        }
        /// <summary>
        /// Delete a relation
        /// </summary>
        /// <param name="relation">Relation to delete</param>
        public void DeleteRelationship(Relationship relation)
        {
            _relationship.Remove(relation);
            UpdateHeroStats();
        }

        public void GetSickness(Sickness sickness)
        {
            foreach (Sickness sick in _sicknesses)
            {
                if (sick.Name == sickness.Name)
                {
                    throw new ArgumentException("dude, u cant get 2 times the same sickness");
                }
            }
            _sicknesses.Add(sickness);
            UpdateHeroStats();
        }

        public void DeleteSickness(Sickness sickness)
        {
            _sicknesses.Remove(sickness);
            UpdateHeroStats();
        }

        public void GetPsycho(Psychology psycho)
        {
            foreach (Psychology psy in _psycho)
            {
                if (psy.Name == psycho.Name)
                {
                    throw new ArgumentException("dude, u cant get 2 times the same psycho");
                }
            }
            _psycho.Add(psycho);
            UpdateHeroStats();
        }

        public void DeletePsycho(Psychology psycho)
        {
            _psycho.Remove(psycho);
            UpdateHeroStats();
        }

        public void UpdateHeroStats()
        {
            InitializedEffectiveStats();
            foreach (Sickness sick in _sicknesses)
            {
                sick.effect(this);
            }

            foreach (Psychology psy in _psycho)
            {
                psy.effect(this);
            }

            foreach (Relationship rel in _relationship)
            {
                rel.Effect(this);
            }

            foreach (Spells spellToUpdate in _spells)
            {
                if (spellToUpdate != null)
                {
                    spellToUpdate.UpdateSpell();
                }

            }

            foreach (BaseItem item in Equipement)
            {
                if (item != null)
                {
                    AddItemStats(item);
                }
            }

        }
        public void ChangeSpellToEquip(Spells spellToEquip, Spells spellToUnequip)
        {
            if (!Spells.Contains(spellToEquip) || !Spells.Contains(spellToUnequip)) throw new ArgumentException("One of these spell wasn't to this hero");
            if (spellToEquip.IsEquiped || !spellToUnequip.IsEquiped) throw new ArgumentException("Spells doesn't have the condition requierd to continue", "IsEquiped");
            spellToEquip.IsEquiped = true;
            spellToUnequip.IsEquiped = false;
            SpellComparer compare = new SpellComparer();
            Array.Sort(Spells, compare);
        }
        public abstract void LevelUp();
        public int Evilness
        {
            get
            {
                return _evilness;
            }

            set
            {
                _evilness = value;
            }
        }


        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public int XpMax
        {
            get
            {
                return _xpMax;
            }

            set
            {
                _xpMax = value;
            }
        }

        public string CharacterClassName
        {
            get
            {
                return _characterClassName;
            }
        }

        public bool IsMale
        {
            get
            {
                return _isMale;
            }

            set
            {
                _isMale = value;
            }
        }

        public int Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public Spells[] Spells
        {
            get
            {
                return _spells;
            }
        }

        public List<Relationship> Relationship
        {
            get
            {
                return _relationship;
            }
        }

        public BaseItem[] Equipement
        {
            get
            {
                return _equipement;
            }

            set
            {
                _equipement = value;
            }
        }

        public List<Sickness> Sicknesses
        {
            get
            {
                return _sicknesses;
            }
        }

        public List<Psychology> Psycho
        {
            get
            {
                return _psycho;
            }
        }

        public BaseBuilding InBuilding
        {
            get
            {
                return _inBuilding;
            }

            set
            {
                _inBuilding = value;
            }
        }

        public string Owner
        {
            get
            {
                return _owner;
            }

            set
            {
                _owner = value;
            }
        }
    }
}
