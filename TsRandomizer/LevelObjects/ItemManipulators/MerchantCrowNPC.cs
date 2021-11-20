using Timespinner.GameAbstractions.Inventory;
using Timespinner.GameObjects.BaseClasses;
using TsRandomizer.IntermediateObjects;
using TsRandomizer.Randomisation;

namespace TsRandomizer.LevelObjects.ItemManipulators
{
    [TimeSpinnerType("Timespinner.GameObjects.NPCs.MerchantCrowNPC")]
    class MerchantCrowNpc : ItemManipulator
    {
        MerchantInventory _merchandiseInventory = new MerchantInventory();
        public MerchantCrowNpc(Mobile typedObject, ItemLocation itemLocation) : base(typedObject, itemLocation)
        {

        }

        protected override void Initialize(SeedOptions options, ItemLocationMap itemLocations)
        {
            _merchandiseInventory.AddItem(EInventoryUseItemType.WarpCard);
            if (Dynamic._isInPresent)
            {
                _merchandiseInventory.AddItem(EInventoryUseItemType.FuturePotion);
                _merchandiseInventory.AddItem(EInventoryUseItemType.FutureEther);

            }
            else
            {
                _merchandiseInventory.AddItem(EInventoryUseItemType.Potion);
                _merchandiseInventory.AddItem(EInventoryUseItemType.Ether);
            }
            _merchandiseInventory.AddItem(EInventoryUseItemType.Biscuit);
            _merchandiseInventory.AddItem(EInventoryUseItemType.Ether);
            _merchandiseInventory.AddItem(EInventoryUseItemType.Antidote);
            _merchandiseInventory.AddItem(EInventoryUseItemType.SandBottle);
            _merchandiseInventory.AddItem(EInventoryUseItemType.ChaosHeal);

            ItemKey bonus_item_present_1 = new ItemKey(2, 3, 131, 181);
            ItemKey bonus_item_shiny_rock_1 = new ItemKey(6, 4, 131, 1);
            ItemKey bonus_item_shiny_rock_2 = new ItemKey(2, 3, 131, 0);
            ItemKey bonus_item_past_1 = new ItemKey(6, 4, 131, 165);
            ItemKey bonus_item_past_2 = new ItemKey(6, 4, 131, 0);

            /*
            if (Dynamic._isInPresent)
            {
                _merchandiseInventory.AddItem(itemLocations[bonus_item_present_1]);
            }
            else
            {
                _merchandiseInventory.AddItem(itemLocations[bonus_item_past_1]);
                _merchandiseInventory.AddItem(itemLocations[bonus_item_past_2]);
            }
            // TODO gate behind shiny rock
            _merchandiseInventory.AddItem(itemLocations[bonus_item_shiny_rock_1]);
            _merchandiseInventory.AddItem(itemLocations[bonus_item_shiny_rock_2]);
            */

            Dynamic._merchandiseInventory = _merchandiseInventory;
        }
    }
}
