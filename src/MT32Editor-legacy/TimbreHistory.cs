namespace MT32Edit_legacy;

/// <summary>
/// Maintains a stack of previous timbre states to facilitate undo/redo function
/// </summary>

internal class TimbreHistory
{
    /// MT32Edit: TimbreHistory class
    /// S.Fryers Apr 2024 
    private const int MAXIMUM_STACK_SIZE = 1000;    // maximum size of undo buffer
    private const int NO_OF_ITEMS_TO_FREE_UP = 100; // amount of space to free up when buffer is full (must be less than MAXIMUM_STACK_SIZE)
    private int actionNo;                           // current stack pointer position
    private int topOfStack;                         // number of items in the stack
    TimbreStructure[] timbreHistory;                // stack of timbre states

    public TimbreHistory(TimbreStructure initialTimbreState)
    {
        actionNo = 0;
        topOfStack = -1;
        timbreHistory = new TimbreStructure[MAXIMUM_STACK_SIZE];
        timbreHistory[0] = initialTimbreState.Clone();
    }

    /// <summary>
    /// Adds a timbreState to the stack
    /// </summary>
    /// <param name="timbreState"></param>
    public void AddTo(TimbreStructure timbreState)
    {
        if (ParseTools.LeftMost(timbreState.GetTimbreName(), MT32Strings.EMPTY.Length) == MT32Strings.EMPTY || IsEqualTo(timbreState))
        {
            //Do not update the undo history if timbre state is [empty] or no changes have been made since last action.
            return;
        }
        actionNo++;
        if (actionNo >= MAXIMUM_STACK_SIZE)
        {
            FreeUpStackSpace();
        }
        timbreHistory[actionNo] = timbreState.Clone();
        topOfStack = actionNo;
    }

    /// <summary>
    /// Frees up space in the undo history if the maximum stack size has been reached.
    /// TimbreHistory array is shifted {NO_OF_ITEMS_TO_FREE_UP} places to the left and stack pointer is decremented accordingly.
    /// Oldest {NO_OF_ITEMS_TO_FREE_UP} items are overwritten.
    /// </summary>
    private void FreeUpStackSpace()
    {
        if (actionNo < MAXIMUM_STACK_SIZE)
        {
            return;
        }
        ConsoleMessage.SendVerboseLine($"Undo buffer full: Freeing up space. Oldest {NO_OF_ITEMS_TO_FREE_UP} records in undo history will be deleted.");
        for (int i = 0; i < MAXIMUM_STACK_SIZE - NO_OF_ITEMS_TO_FREE_UP; i++)
        {
            timbreHistory[i] = timbreHistory[i + NO_OF_ITEMS_TO_FREE_UP].Clone();
        }
        actionNo = MAXIMUM_STACK_SIZE - NO_OF_ITEMS_TO_FREE_UP - 1;
        topOfStack = actionNo;
    }

    /// <summary>
    /// Returns the previous timbre state in the stack and decrements the stack pointer.
    /// If there is only one item in the stack, returns that item and leaves the pointer unchanged. 
    /// </summary>
    /// <returns>TimbreStructure</returns>
    public TimbreStructure Undo()
    {
        if (actionNo > 0)
        {
            actionNo--;
            ConsoleMessage.SendVerboseLine("Action undone.");
        }
        return timbreHistory[actionNo].Clone();
    }

    /// <summary>
    /// Returns the next timbre state in the stack and increments the stack pointer.
    /// If the pointer is at the top of the stack, returns that item and leaves the pointer unchanged.
    /// </summary>
    /// <returns>TimbreStructure</returns>
    public TimbreStructure Redo() 
    {
        if (actionNo < topOfStack)
        {
            actionNo++;
            ConsoleMessage.SendVerboseLine("Action redone.");
        }
        return timbreHistory[actionNo].Clone();
    }

    /// <summary>
    /// Clears the timbre history stack, with the top item becoming the bottom of the new stack.
    /// </summary>
    public void Clear(TimbreStructure timbreState)
    {
        if (topOfStack == -1)
        {
            return;
        }
        actionNo = 0;
        topOfStack = 0;
        timbreHistory[0] = timbreState.Clone();
    }

    /// <summary>
    /// Returns an integer representing the current stack size.
    /// </summary>
    public int GetTopOfStack()
    {
        return topOfStack;
    }

    /// <summary>
    /// Returns the current TimbreHistory stack pointer position.
    /// </summary>
    public int GetLatestActionNo()
    {
        return actionNo;
    }

    /// <summary>
    /// Returns true if the provided TimbreStructure is identical to the one at the top of the stack.
    /// If not, returns false.
    /// </summary>
    public bool IsEqualTo(TimbreStructure timbreToCompare)
    {
        return timbreHistory[actionNo].CheckSum() == timbreToCompare.CheckSum();
    }

    /// <summary>
    /// Returns true if the provided TimbreStructure is different to the one at the top of the stack.
    /// If both timbres are the same, returns false.
    /// </summary>
    public bool IsDifferentTo(TimbreStructure timbreToCompare)
    {
        return !IsEqualTo(timbreToCompare);
    }
}
