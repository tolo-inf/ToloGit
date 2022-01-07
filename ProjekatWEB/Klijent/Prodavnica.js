export class Prodavnica{

    constructor(cenaIgre, korpa, igraFK){
        //this.id = id;
        this.idProdavnice = idProdavnice;
        this.cenaIgre = cenaIgre;
        this.korpa = korpa;
        this.igraFK = igraFK;
        this.imeIgre = this.pribaviImeIgre(this.igraFK);
    }
    
    crtaj(host)
    {   
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML=this.imeIgre;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.cenaIgre;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.korpa;
        tr.appendChild(el);
    }

    pribaviImeIgre(idIgre)
    {
        //PreuzmiImeIgre/{idIgre}
        fetch("https://localhost:5001/Ocena/PreuzmiImeIgre/"+idIgre,
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