
using System;

public static class EventHandler
{
    public static event Action<ItemDetails, int> UpdateUI;

    public static event Action UnloadItem;

    public static event Action LoadItem;

    public static event Action<ItemDetails, bool> TakeItem;

    public static event Action<ItemName> ItemUsed;

    public static event Action<int> ChangeItem;

    public static event Action<string> ShowDialog;

    public static event Action<GameStata> ChangeGameStata;

    public static event Action CheckMiniGame;

    public static event Action<string> MiniGameOver; 

    public static void CallUpdateUI(ItemDetails itemDetails, int index)
    {
        UpdateUI?.Invoke(itemDetails, index);
    }

    public static void CallUnloadItem()
    {
        UnloadItem?.Invoke();
    }
    
    public static void CallLoadItem()
    {
        LoadItem?.Invoke();
    }

    public static void CallTakeItem(ItemDetails itemDetails, bool isSelected)
    {
        TakeItem?.Invoke(itemDetails, isSelected);
    }

    public static void CallItemUsed(ItemName itemName)
    {
        ItemUsed?.Invoke(itemName);
    }

    public static void CallChangeItem(int index)
    {
        ChangeItem?.Invoke(index);
    }

    public static void CallShowDialog(string dialog)
    {
        ShowDialog?.Invoke(dialog);
    }

    public static void CallChangeGameStata(GameStata gameStata)
    {
        ChangeGameStata?.Invoke(gameStata);
    }
    
    public static void CallCheckMiniGame()
    {
        CheckMiniGame?.Invoke();
    }

    public static void CallMiniGameOver(string gameName)
    {
        MiniGameOver?.Invoke(gameName);
    }
}
