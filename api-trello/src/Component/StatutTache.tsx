import React from 'react';
import { Card } from 'primereact/card';
import { IProjetDetails, IStatut } from '../Page/Projet';
import CardTache from './CardTache';

interface IStatutTacheProp {
    projetDetails: IProjetDetails | null
    findNomResponsable: (Idresponsable: number | null) => string,
    statuts: IStatut[] | null,
}

function StatutTache({ projetDetails, findNomResponsable, statuts }: IStatutTacheProp) {

    if (!projetDetails || !statuts) {
        return <div>Loading...</div>;
    }
    console.log("statuts[1]", statuts[1])
    console.log("statut", projetDetails.taches.filter(t => t.idstatutTache === 11))


    return (
        //drag and drop context
        <div className="flex justify-content-center">
            {statuts?.map((statut) => (
                // droppable
                <Card
                    key={statut.idstatutTache}
                    title={statut.libelleStatut}
                    className="md:w-25rem"
                >

                    <CardTache key={statut.idstatutTache} taches={projetDetails.taches.filter(t => t.idstatutTache === statut.idstatutTache)} findNomResponsable={findNomResponsable} />
                </Card>
            ))}

        </div >
    );
}

export default StatutTache;
