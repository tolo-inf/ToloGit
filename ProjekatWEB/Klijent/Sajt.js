export class Sajt{

    constructor(listaIgara){
        this.listaIgara = listaIgara;
        this.kontejner = null;
    }
    
    crtaj(host){
        this.kontejner=document.createElement("div");
        this.kontejner.className="GlavniKontejner";
        host.appendChild(this.kontejner);

        let kontForma = document.createElement("div");
        kontForma.className="Forma";
        this.kontejner.appendChild(kontForma);

        this.crtajFormu1(kontForma);
        this.crtajFormu2(kontForma);
        this.crtajFormu3(kontForma);
        this.crtajIgru(this.kontejner);
        this.crtajKorpu(this.kontejner);
        this.crtajNagradu(this.kontejner);
        this.crtajSliku(this.kontejner);

    }
    crtajIgru(host){

        let kontIgra = document.createElement("div");
        kontIgra.className="Prikaz";
        host.appendChild(kontIgra);

        var tabela = document.createElement("table");
        tabela.className="tabela";
        kontIgra.appendChild(tabela);

        var tabelahead= document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className="TabelaPodaci";
        tabela.appendChild(tabelaBody);

        let th;
        var zag=["Naziv", "Zanr", "Godina Izlaska", "Developer", "Publisher", "Ocena"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            tr.appendChild(th);
        })
    }

    crtajRed(host){
        let red = document.createElement("div");
        red.className="red";
        host.appendChild(red);
        return red;
    }
}