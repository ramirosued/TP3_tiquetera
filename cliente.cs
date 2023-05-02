class Cliente
{
public int DNI{get;private set;}
public string Apellido{get;set;}
public string Nombre{get;set;}    
public DateTime FechaInscripcion{get;set;}
public int TipoEntrada{get;set;}
public int TotalAbono{get;set;}

public Cliente(int dni, string ape, string nom, DateTime fechaIn, int tipoEn, int totalAbo)
{
    DNI=dni;
    Apellido=ape;
    Nombre=nom;
    FechaInscripcion=fechaIn;
    TipoEntrada=tipoEn;
    TotalAbono=totalAbo;
}
public Cliente(){
    
}

}