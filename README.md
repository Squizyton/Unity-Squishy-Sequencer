# Unity Squishy Sequencer

## What Is This?

Unity's Timeline/Animator are annoying to work with, especially when trying to call events, I've tried to mitigate this with asset that I've made. 

Being able to utilize Event-Based features while also being able to use Timeline/Animator with ease, while also being flexible enough to allow any developer/designer to add their own Event's to the sequencer


# Set Up

The Squishy Sequencer consists of *two* main components. The `Cutscene Player` and the `Cutscene Sequencer`. The `Cutscene Player` just plays the sequence. The `Cutscene Sequencer` is the bread and butter.

Attach the `Cutscene Player` to any object. And attach the Sequencer to any group of objects you want animate

After this, add either the provided events to the sequence, or your own.

The Order is played from **Top To Bottom**.


## Example

![image](https://github.com/user-attachments/assets/cd501512-97aa-406a-896c-3f5067f3ce8e)



# Creating Custom Events.


Since this asset utilizes the Odin Inspector. Adding events is easy!

Create a script and have it inherit the `CutsceneAction` class.

After that, add in what you need in `OnStart` `OnExecuting` and `OnFinish`. (Naming Convention does not matter)

## Example
```cs
public class CS_Example : CutsceneAction
{
    [VerticalGroup("Special Parameters")]
    private Transform _transformToRotate;
    
    public override void OnStart()
    {
    }

    public override Status Executing()
    {
        if (_transformToRotate.rotation.x != 90)
        {
            // --- Rotate object

            return Status.Running;
        }
        //When you want the Event to Stop. YOU MUST RETURN Status.Finished
        return Status.Finished;
    }

    public override void OnEnd()
    {
     
    }
}
```


And that's it!
