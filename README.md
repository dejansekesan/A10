````markdown
# TB Програм – Personal Notes

### 🖋 General UI Setup

- Change font to **Consolas** for fixed alignment between `label7` and `listBox`.
- Just **make charts larger** (without using Properties) if they're small enough – literally drag them to be larger.
- `label7` is the **only one you need above the `listBox`** on `Form1`.

---

### 🧰 ToolStrip Settings

- In **ToolStrip**, specifically buttons:
  - In Properties, set the image to be **above the text**.
  - **Add the image in the ToolStrip menu**, not through the individual button's properties.

---

### 🔤 Text Alignment for ListBox and Label7

There are lines in the code, specifically in `Pecaros.cs` and `Form1.cs`, which determine the gap between words in the `ListBox` and `label7`.

Original `ToString()` method:

```csharp
public override string ToString()
{
    return String.Format("{0,-6}{1,-15}{2,-15}{3,-20}{4,-15}{5,-12}", 
        this.PecarosID, this.Ime, this.Prezime, this.Adresa, this.Grad, this.Telefon);
}
````

🔁 **Change this format string:**

```
{0,-6}{1,-15}{2,-15}{3,-20}{4,-15}{5,-12}
```

⬇️ **To this one:**

```
{0,-6}{1,-15}{2,-15}{3,-25}{4,-15}{5,-12}
```

Make the change in **both files**: `Pecaros.cs` and `Form1.cs`.

---

This file is just for personal reference when working on layout, alignment, and formatting in the project.

```

You can now paste this directly into your `README.md` file — it will look neat and readable without needing horizontal scrolling. Let me know if you want this broken into sections or saved as a downloadable file.
```
