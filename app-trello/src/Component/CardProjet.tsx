import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import AddProjet from './AddProjet';
import { ScrollPanel } from 'primereact/scrollpanel';


interface ICardProjetProps {
    projet: {
        idprojet: number,
        nomProjet: string;
        idresponsable: number;
    }[],
    utilisateur: {
        idutilisateur: number, nom: string; prenom: string; motDePasse: string; description: string; photo: string; poste: string
    }[];
    findNomResponsable: (Idresponsable: number | null) => string
}
function CardProjet({ projet, utilisateur, findNomResponsable }: ICardProjetProps) {
    const [selectedProjet, setSelectedProjet] = useState<{
        idprojet: number,
    } | null>(null);

    const header = (
        <>
            <img alt="Card" src="https://primefaces.org/cdn/primereact/images/usercard.png" />
        </>
    );
    const handleVoirClick = (id: number) => {
        console.log('ID du projet :', selectedProjet);
        if (id !== undefined && !isNaN(id)) {
            console.log('ID du projet :', id);
        }
    };
    console.log(projet)
    console.log(utilisateur)
    return (
        <div className="card flex justify-content-center">

            <Card title="Liste" subTitle="PROJET" header={header} className="md:w-25rem">
                <AddProjet findNomResponsable={findNomResponsable} utilisateur={utilisateur} />
                <ScrollPanel style={{ width: '100%', height: '450px' }}>
                    <ul className="m-0">
                        {projet.map((item) => (

                            <li key={item.idprojet} className="flex-initial flex align-items-center justify-content-between py-3">
                                <img alt="" src={""} />
                                <span className="list-none">{item.nomProjet}</span>
                                <Link to={`/projet/${item.idprojet}`} onClick={() => handleVoirClick(item.idprojet)}>
                                    <Button>Voir</Button>
                                </Link>
                            </li>
                        ))}
                    </ul>
                </ScrollPanel>

            </Card>
        </div>
    )
};

export default CardProjet;