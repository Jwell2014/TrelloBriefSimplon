import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import { IProjetDetails, ITache } from '../Page/Projet';

import React from 'react';
import { Checkbox } from 'primereact/checkbox';
import { ScrollPanel } from 'primereact/scrollpanel';

interface ICardTache {
    taches: ITache[] | null
    findNomResponsable: (Idresponsable: number | null) => string,
}

function CardTache({ taches, findNomResponsable }: ICardTache) {

    if (!taches) {
        return <div>Loading...</div>;
    }


    return (
        <div className="card flex justify-content-center">
            <ScrollPanel style={{ width: 'auto', height: '500px' }}>
                {taches.map((tache) => (
                    //Graggable
                    <Card
                        key={tache.idtache}
                        title={tache.titre}
                        subTitle={findNomResponsable(tache.idresponsable)}
                        className="md:w-25rem"
                    >
                        <h4>Date limite</h4>
                        <p className="m-0">{tache.dateLimite}</p>
                        <h4>Description</h4>
                        <p className="m-0">{tache.description}</p>

                        <h4>Actions :</h4>
                        <ul>
                            {tache.actions.map((action) => (

                                <Card key={action.idaction}>
                                    <h4>Description de l'action : </h4>
                                    <p>{action.description}</p>
                                    <Checkbox
                                        checked={action.estTerminee}
                                        disabled
                                    />
                                    <label htmlFor="cb1" className="p-checkbox-label mx-3">Est terminée</label>
                                </Card>

                            ))}
                        </ul>
                    </Card>
                ))}
            </ScrollPanel>
        </div>
    );

};

export default CardTache;