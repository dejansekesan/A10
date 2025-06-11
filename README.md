
# personal notes

– change font to **Consolas** for fixed alignment between **label7** and **listbox**  
– just make charts larger **(without properties)** if they're small enough (literally drag it to be larger)   
– **label7** is the **only** one you need above the **listbox** on **Form1**  
– in **toolstrip**, **specifically buttons**, there is an option in **properties** to make the **image** be **above the text**, also add the **image** in the **menu** of the **toolstrip** and **not** the **properties** of the **button**  
– there are **these lines in the code**, specifically in the **Pecaros.cs** and **Form1.cs** which determine the **gap between words** in **listbox** and the **label7**:  

- Pecaros.cs:  
```csharp
public override string ToString()
{
    return String.Format("{0,-6}{1,-15}{2,-15}{3,-20}{4,-15}{5,-12}", this.PecarosID, this.Ime, this.Prezime, this.Adresa, this.Grad, this.Telefon);
}
```
- Form1.cs:  
```csharp
public override string ToString()
{
    private void Form1_Load(object sender, EventArgs e)
{
    label7.Text = String.Format("{0,-6}{1,-15}{2,-15}{3,-25}{4,-15}{5,-12}", "Šifra", "Ime", "Prezime", "Adresa", "Grad", "Telefon");
    comboBox1.DisplayMember = "Grad";
    comboBox1.ValueMember = "GradID";
    comboBox1.DataSource = Pecaros.UcitajSve();
    PrikaziPodatke();
}
}
```

**change this string:**
`{0,-6}{1,-15}{2,-15}{3,-20}{4,-15}{5,-12}`

**to this one:**
`{0,-6}{1,-15}{2,-15}{3,-25}{4,-15}{5,-12}`

**in both files**

