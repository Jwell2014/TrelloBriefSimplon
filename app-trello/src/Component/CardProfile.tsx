import React, { useState } from 'react';
import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import { Avatar } from 'primereact/avatar';
import { Dialog } from 'primereact/dialog';




interface ICardProfileProps {
    utilisateur: {
        idutilisateur: number,
        nom: string;
        prenom: string;
        photo: string;
        poste: string;
        description: string;
    }[]
}
function CardProfile({ utilisateur }: ICardProfileProps) {
    const [visible, setVisible] = useState(false);
    const [selectedUser, setSelectedUser] = useState<{
        idutilisateur: number, nom: string; prenom: string; description: string; photo: string; poste: string
    } | null>(null);
    const header = (
        <>
            <img alt="Card" src="https://primefaces.org/cdn/primereact/images/usercard.png" />
        </>
    );
    const footerContent = (
        <div>
            <Button label="Fermer" icon="pi pi-check" onClick={() => { setVisible(false) }} autoFocus />
        </div>
    );

    return (
        <div className="card w-6 mx-5 flex justify-content-center">
            <Card title="Liste" subTitle="UTILISATEURS" header={header} className="w-full">
                <ul className="m-0 ">
                    {utilisateur.map(item => (
                        <>

                            <div className='flex-initial flex align-items-center justify-content-between py-3'>
                                <Avatar image={item.photo} className="mr-2" size="large" shape="circle" />
                                <li className='list-none' key={item.idutilisateur}>{item.nom} {item.prenom}</li>
                                <Button label="Voir" icon="pi pi-check" onClick={() => { setVisible(true); setSelectedUser(item) }} />
                            </div>
                            <Dialog header="Profile" visible={visible} style={{ width: '50vw' }} onHide={() => setVisible(false)} footer={footerContent}>
                                {selectedUser && (
                                    <>
                                        <p>Nom: {selectedUser.nom}</p>
                                        <p>Prénom: {selectedUser.prenom}</p>
                                        <p>Poste: {selectedUser.poste}</p>
                                        <p>Description: {selectedUser.description}</p>
                                        <img alt='ok' src={selectedUser.photo} className='w-1' />
                                    </>
                                )}
                            </Dialog>
                        </>

                    ))}
                </ul>
            </Card>
        </div>
    )
};

export default CardProfile;