import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import React from 'react';


interface ICardProfileProps {
    utilisateur: {
        idutilisateur: number,
        nom: string;
        prenom: string;
        photo: string;
    }[]
}
function CardProfile({ utilisateur }: ICardProfileProps) {
    const header = (
        <>
            <img alt="Card" src="https://primefaces.org/cdn/primereact/images/usercard.png" />
        </>
    );

    return (
        <div className="card flex justify-content-center">
            <Card title="Liste" subTitle="UTILISATEURS" header={header} className="md:w-25rem">
                <ul className="m-0 ">
                    {utilisateur.map(item => (
                        <div className='flex-initial flex align-items-center justify-content-between py-3'>
                            <img alt='' src={item.photo} />
                            <li className='list-none' key={item.idutilisateur}>{item.nom} {item.prenom}</li>
                            <Button label="Voir" icon="pi pi-check" />
                        </div>

                    ))}
                </ul>
            </Card>
        </div>
    )
};

export default CardProfile;