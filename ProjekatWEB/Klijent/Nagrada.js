export class Nagrada{

    constructor(id, nazivOrg, kategorija, igraFK){
        this.id = id;
        this.nazivOrg = nazivOrg;
        this.kategorija = kategorija;
        this.igraFK = igraFK;
    }
    
    crtaj(host)
    {   
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML=this.nazivOrg;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.kategorija;
        tr.appendChild(el);
    }
}