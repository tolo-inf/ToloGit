import { Sajt } from "./Sajt.js";
import { Igra } from "./Igra.js";

var listaIgara =[];

fetch("https://localhost:5001/Igra/PreuzmiIgre")
.then(p=>{
    p.json().then(igre=>{
        igre.forEach(igra => {
            var p = new Igra(igra.id, igra.naziv, igra.zanr, igra.godinaIzlaska, igra.developer, igra.publisher, igra.ocene, igra.prodavnice, igra.nagrade);
            listaIgara.push(p);
        })

        var s = new Sajt(listaIgara);
        s.crtaj(document.body);   
    })
})
console.log(listaIgara);

