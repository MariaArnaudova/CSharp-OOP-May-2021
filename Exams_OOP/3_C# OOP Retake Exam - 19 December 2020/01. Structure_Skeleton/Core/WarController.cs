using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> partyCharacter;
        private List<Item> itemPool;
        public WarController()
        {
            this.partyCharacter = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];

            Character character = default;

            if (characterType == "Priest")
            {
                character = new Priest(args[1]);
            }
            else if (characterType == "Warrior")
            {
                character = new Warrior(args[1]);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            this.partyCharacter.Add(character);
            return string.Format(string.Format(SuccessMessages.JoinParty, args[1]));
        }

        public string AddItemToPool(string[] args)
        {
            Item item = default;

            string itemName = args[0];

            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            this.itemPool.Add(item);
            return string.Format(string.Format(SuccessMessages.AddItemToPool, itemName));
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.partyCharacter.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));

            }

            Item lastItem = this.itemPool.Last();

            character.Bag.AddItem(lastItem);

            return string.Format(string.Format(SuccessMessages.PickUpItem, characterName, lastItem.GetType().Name));
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.partyCharacter.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return string.Format(string.Format(SuccessMessages.UsedItem, characterName, itemName));

        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            partyCharacter = this.partyCharacter
                    .OrderByDescending(x => x.IsAlive)
                    .ThenByDescending(x => x.Health).ToList();

            foreach (var character in partyCharacter)
            {
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats
                    , character.Name
                    , character.Health
                    , character.BaseHealth
                    , character.Armor
                    , character.BaseArmor
                    , (character.IsAlive ? "Alive" : "Dead")));
            }

            return sb.ToString().TrimEnd();

        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.partyCharacter.FirstOrDefault(x => x.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            Character receiver = this.partyCharacter.FirstOrDefault(x => x.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker.GetType().Name == "Warrior")
            {
                IAttacker warriorAttacker = new Warrior(attackerName);
                warriorAttacker.Attack(receiver);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter
              , attackerName
              , receiverName
              , attacker.AbilityPoints
              , receiverName
              , receiver.Health
              , receiver.BaseHealth
              , receiver.Armor
              , receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }

            return sb.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.partyCharacter.FirstOrDefault(x => x.Name == healerName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            Character healingReceiver = this.partyCharacter.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (healer.GetType().Name == "Warrior")
            {
                throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healerName);
            }

            IHealer foundHealer = new Priest(healerName);

            foundHealer.Heal(healingReceiver);

            return string.Format(SuccessMessages.HealCharacter
                  , healerName
                  , healingReceiverName
                  , healer.AbilityPoints
                  , healingReceiverName
                  , healingReceiver.Health);
        }
    }
}
