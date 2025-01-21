import { Button } from 'primereact/button';
import { Card } from 'primereact/card';
import React, { useState } from 'react';
import { Dialog } from 'primereact/dialog';
import { ScrollPanel } from 'primereact/scrollpanel';


interface ICardUtilisateurProps {
    utilisateur: {
        idutilisateur: number, nom: string; prenom: string; motDePasse: string; description: string; photo: string; poste: string
    }[]
}
function CardUtilisateur({ utilisateur }: ICardUtilisateurProps) {
    const header = (
        <>
            <img alt="Card" src="https://primefaces.org/cdn/primereact/images/usercard.png" />
        </>
    );
    const [visible, setVisible] = useState(false);
    const [selectedUser, setSelectedUser] = useState<{
        idutilisateur: number, nom: string; prenom: string; motDePasse: string; description: string; photo: string; poste: string
    } | null>(null);

    const footerContent = (
        <div>
            <Button label="No" icon="pi pi-times" onClick={() => setVisible(false)} className="p-button-text" />
            <Button label="Fermer" icon="pi pi-check" onClick={() => { setVisible(false) }} autoFocus />
        </div>
    );

    return (
        <div className="card flex justify-content-center">
            <Card title="Liste" subTitle="UTILISATEURS" header={header} className="md:w-25rem">
                <ScrollPanel style={{ width: '100%', height: '550px' }}>
                    <ul className="m-0 ">
                        {utilisateur.map(item => (
                            <div className='flex-initial flex align-items-center justify-content-between py-3'>
                                <img alt='' src={item.photo} />
                                <li className='list-none' key={item.idutilisateur}>{item.nom} {item.prenom}</li>
                                <div className="card flex justify-content-center">
                                    <Button label="Show" icon="pi pi-external-link" onClick={() => { setVisible(true); setSelectedUser(item) }} />
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
                                </div>
                            </div>

                        ))}
                    </ul>
                </ScrollPanel>
            </Card>
        </div>
    )
};

export default CardUtilisateur;