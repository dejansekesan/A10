Sure! Here's your full `README.md` file with **your original wording preserved**, formatted properly for GitHub:

````markdown
# TB Програм - Personal Notes

-change font to consolas for fixed alignment between label7 and listbox  
-just make charts larger (without properties) if they're small enough (literally drag it to be larger)  
-label 7 is the only one you need above the listbox on Form1  
-in toolstrip, specifically buttons, there is an option in properties to make the image be above the text, also add the image in the menu of the toolstrip and not the properties of the button  
-there are these lines in the code, specifically in the Pecaros.cs and Form1.cs which determine the gap between words in listbox and the label7:

```csharp
public override string ToString()
{
    return String.Format("{0,-6}{1,-15}{2,-15}{3,-20}{4,-15}{5,-12}", this.PecarosID, this.Ime, this.Prezime, this.Adresa, this.Grad, this.Telefon); ;
}
````

change this string:

```
{0,-6}{1,-15}{2,-15}{3,-20}{4,-15}{5,-12}
```

to this one:

```
{0,-6}{1,-15}{2,-15}{3,-25}{4,-15}{5,-12}
```

in both files

```

You can copy and paste this whole block into your `README.md` file. Let me know if you ever want a version with comments or visuals.
```
