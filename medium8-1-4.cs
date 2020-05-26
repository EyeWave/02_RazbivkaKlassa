using System;

namespace Task
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var player = new Player("Mol`", 144128)
            {
                Mover = new ItemMover(144, 128, 20),
                Attacker = new ItemAttacker(36, uint.MaxValue),
            };
        }
    }

    internal class Player : AbstractItem, IMover, IAttacker
    {
        public Player(string name, int age) : base(name, age)
        {
        }

        private ItemMover _mover;

        public ItemMover Mover
        {
            get => _mover;
            set => _mover = _mover == null ? value : _mover;
        }

        private ItemAttacker _attacker;

        public ItemAttacker Attacker
        {
            get => _attacker;
            set => _attacker = _attacker == null ? value : _attacker;
        }

        public bool IsReloading => throw new NotImplementedException();

        public void Attack()
        {
            if (_attacker != null && !IsReloading)
                throw new NotImplementedException();
        }

        public void Move(float x, float y)
        {
            if (_mover != null && !IsReloading)
                throw new NotImplementedException();
        }
    }

    internal abstract class AbstractItem
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        protected AbstractItem(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    internal interface IMover
    {
        ItemMover Mover { get; set; }

        void Move(float x, float y);
    }

    internal interface IAttacker
    {
        ItemAttacker Attacker { get; set; }
        bool IsReloading { get; }

        void Attack();
    }

    internal class ItemMover
    {
        public float MovementDirectionX { get; private set; }
        public float MovementDirectionY { get; private set; }
        public float MovementSpeed { get; private set; }

        public ItemMover(float movementDirectionX, float movementDirectionY, uint movementSpeed)
        {
            MovementDirectionX = movementDirectionX;
            MovementDirectionY = movementDirectionY;
            MovementSpeed = movementSpeed;
        }
    }

    internal class ItemAttacker
    {
        public float WeaponCooldown { get; private set; }
        public int WeaponDamage { get; private set; }

        public ItemAttacker(uint weaponCooldown, uint weaponDamage)
        {
            WeaponCooldown = weaponCooldown;
            WeaponDamage = (int)weaponDamage;
        }
    }
}
