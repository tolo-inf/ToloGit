export class Igra{

    constructor(id, naziv, zanr, godinaIzlaska, developer, publisher){
        this.id = id;
        this.naziv = naziv;
        this.zanr = zanr;
        this.godinaIzlaska = godinaIzlaska;
        this.developer = developer;
        this.publisher = publisher;
        this.ocene = this.pribaviProsecnuOcenu(this.id);
        //this.prodavnice = prodavnice;
        //this.nagrade = nagrade;
    }

    crtaj(host){
       
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML=this.naziv;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.zanr;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.godinaIzlaska;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.developer;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.publisher;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.ocene;
        tr.appendChild(el);
    }

    pribaviProsecnuOcenu(idIgre)
    {
        //PreuzmiProsecnuOcenu/{idIgre}
        fetch("https://localhost:5001/Ocena/PreuzmiProsecnuOcenu/"+idIgre,
        {
            method:"GET"
        }).then(s=>{
            if(s.ok)
            {
                s.json().then(data=>
                    {
                        return data;
                    })
                }
            })
    }
}