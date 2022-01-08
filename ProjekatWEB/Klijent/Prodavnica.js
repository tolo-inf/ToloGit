export class Prodavnica{

    constructor(korpa, igraFK){
        //this.id = id;
        //this.idProdavnice = idProdavnice;
        //this.cenaIgre = this.pribaviCenuIgre(this.igraFK)
        this.korpa = korpa;
        this.igraFK = igraFK;
        //this.imeIgre = this.pribaviImeIgre(this.igraFK);
        //this.racun = this.cenaIgre*this.korpa;
    }
    
    crtaj(host)
    {   
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var cenaIgre = this.pribaviCenuIgre(this.igraFK);
        var imeIgre = this.pribaviImeIgre(this.igraFK);
        var racun = cenaIgre*this.korpa;
        console.log(cenaIgre);
        console.log(imeIgre);
        console.log(racun);

        var el = document.createElement("td");
        el.innerHTML=imeIgre;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=cenaIgre;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.korpa;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=racun;
        tr.appendChild(el);
    }

    pribaviImeIgre(idIgre)
    {
        console.log(idIgre);
        //PreuzmiImeIgre/{idIgre}
        fetch("https://localhost:5001/Igra/PreuzmiImeIgre/"+idIgre,
        {
            method:"GET"
        }).then(s=>{
            if(s.ok)
            {
                //s.json().then(s=>
                    //{
                        console.log(s.text);
                        return s.text;
                    //})
                }
            })
    }

    pribaviCenuIgre(idIgre)
    {
        console.log(idIgre);
        //PreuzmiCenuIgre/{idIgre}
        fetch("https://localhost:5001/Prodavnica/PreuzmiCenuIgre/"+idIgre,
        {
            method:"GET"
        }).then(s=>{
            if(s.ok)
            {
                s.json().then(data=>
                    {
                        console.log(data);
                        return data;
                    })
            }
        })
    }
}