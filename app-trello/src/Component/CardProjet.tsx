import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import AddProjet from './AddProjet';
import { ScrollPanel } from 'primereact/scrollpanel';
import { Avatar } from 'primereact/avatar';



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

    return (
        <div className="card w-6 mx-5 flex justify-content-center">

            <Card title="Liste" subTitle="PROJET" header={header} className="w-full">
                <AddProjet findNomResponsable={findNomResponsable} utilisateur={utilisateur} />
                <ScrollPanel style={{ width: '100%', height: '450px' }}>
                    <ul className="m-0">
                        {projet.map((item, key) => (
                            <li key={key} className="flex-initial flex align-items-center justify-content-between py-3">
                                <Avatar image="https://plus.unsplash.com/premium_photo-1661290256778-3b821d52c514?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8cHJvamV0fGVufDB8fDB8fHww" className="mr-2" size="large" shape="circle" />
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