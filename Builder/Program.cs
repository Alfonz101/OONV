using System;
using System.Collections.Generic;

namespace Builder
{
    public interface IBuilder
    {
        void Reset();
        void SetMaxHealth(int maxHealth);
        void SetClassType(string classType);
        void SetName(string name);
        void SetOrigin(string origin);
        void SetStartingGift(string gift);
        Character GetCharacter();
    }

    public class CreateKnight : IBuilder
    {
        private Character _character = new Character();

        public CreateKnight()
        {
            Reset();
        }

        public void Reset()
        {
            _character = new Character();
        }

        public void SetMaxHealth(int maxHealth)
        {
            _character.MaxHealth = maxHealth;
        }

        public void SetClassType(string classType)
        {
            _character.ClassType = classType;
        }

        public void SetName(string name)
        {
            _character.Name = name;
        }

        public void SetOrigin(string origin)
        {
            _character.Origin = origin;
        }

        public void SetStartingGift(string gift)
        {
            _character.StartingGift = gift;
        }

        public Character GetCharacter()
        {
            var result = _character;
            Reset();
            return result;
        }
    }

    public class CreateDeprived : IBuilder {
        private Character _character = new Character();
        public CreateDeprived() {
            Reset();
        }

        public void Reset() {
            _character = new Character();
        }

        public void SetMaxHealth(int maxHealth) {
            _character.MaxHealth = maxHealth;
        }

        public void SetClassType(string classType) {
            _character.ClassType = classType;
        }

        public void SetName(string name) {
            _character.Name = name;
        }

        public void SetOrigin(string origin) {
            _character.Origin = origin;
        }

        public void SetStartingGift(string gift) {
            _character.StartingGift = gift;
        }

        public Character GetCharacter() {
            var result = _character;
            Reset();
            return result;
        }
    }

    public class Character
    {
        public int MaxHealth { get; set; }
        public string ClassType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string StartingGift { get; set; } = string.Empty;

        public void ShowCharacter()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {ClassType}");
            Console.WriteLine($"MaxHealth: {MaxHealth}");
            Console.WriteLine($"Origin: {Origin}");
            Console.WriteLine($"Starting Gift: {StartingGift}");
        }

    }

    public class Director
    {
        private IBuilder _builder = null!;
        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildKnight()
        {
            _builder.Reset();
            _builder.SetMaxHealth(200);
            _builder.SetClassType("Knight");
            _builder.SetName("Knight Alfonz");
            _builder.SetOrigin("Human");
            _builder.SetStartingGift("Divine Blessing");
        }

        public void BuildDeprived()
        {
            _builder.Reset();
            _builder.SetMaxHealth(100);
            _builder.SetClassType("Deprived");
            _builder.SetName("Ryan Renolds");
            _builder.SetOrigin("Unknown");
            _builder.SetStartingGift("Broken Straight Sword");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("\nBuilding Characters using Builder (and director) Pattern:\n");
            var director = new Director();
            var knightBuilder = new CreateKnight();
            director.Builder = knightBuilder;
            director.BuildKnight();
            Character knight = knightBuilder.GetCharacter();
            knight.ShowCharacter();
            Console.WriteLine("\n");
            var deprivedBuilder = new CreateDeprived();
            director.Builder = deprivedBuilder;
            director.BuildDeprived();
            Character deprived = deprivedBuilder.GetCharacter();
            deprived.ShowCharacter();
            Console.WriteLine("\n");
        }
    }
}