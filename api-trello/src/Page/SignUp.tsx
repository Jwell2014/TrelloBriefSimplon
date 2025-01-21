import axios from 'axios';
import { Button } from 'primereact/button';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import React, { useState } from 'react';

interface ISignUpProps {
    setConnected: React.Dispatch<React.SetStateAction<boolean>>
}

function SignUp({ setConnected }: ISignUpProps) {
    const [visible, setVisible] = useState(false);
    const [nom, setNom] = useState('');
    const [prenom, setPrenom] = useState('');
    const [password, setPassword] = useState('');
    const [poste, setPoste] = useState('');
    const [description, setDescription] = useState('');
    const [photo, setPhoto] = useState('');



    const createUtilisateur = async () => {
        console.log(nom)
        console.log(password)

        try {
            const response = await axios.post('https://localhost:7203/api/Utilisateur', {
                "nom": nom,
                "prenom": prenom,
                "motDePasse": password,
                "poste": poste,
                "description": description,
                "photo": photo
            }, {
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            // La réponse réussie est dans response.data
            console.log(response.data);
            setConnected(response.data)
            setVisible(false)

        } catch (error) {
            console.error('Erreur lors de la connexion :', error);
        }
    };
    const footerContent = (
        <div>
            <Button label="Annulee" icon="pi pi-times" onClick={() => setVisible(false)} className="p-button-text" />
            <Button label="Creer" icon="pi pi-check" onClick={createUtilisateur} autoFocus />
        </div>
    );
    return (
        <div className="card flex justify-content-center">
            <Button label="Show" icon="pi pi-external-link" onClick={() => setVisible(true)} />
            <Dialog header="Créer un compte" visible={visible} style={{ width: '50vw' }} onHide={() => setVisible(false)} footer={footerContent}>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">Nom</label>
                    <InputText
                        id="Nom"
                        type="text"
                        className="w-12rem"
                        value={nom}
                        onChange={(e) => setNom(e.target.value)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">prenom</label>
                    <InputText
                        id="prenom"
                        type="text"
                        className="w-12rem"
                        value={prenom}
                        onChange={(e) => setPrenom(e.target.value)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">Password</label>
                    <InputText
                        id="password"
                        type="password"
                        className="w-12rem"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">Password</label>
                    <InputText
                        id="password"
                        type="password"
                        className="w-12rem"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">poste</label>
                    <InputText
                        id="poste"
                        type="text"
                        className="w-12rem"
                        value={poste}
                        onChange={(e) => setPoste(e.target.value)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">description</label>
                    <InputText
                        id="description"
                        type="text"
                        className="w-12rem"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">photo</label>
                    <InputText
                        id="photo"
                        type="text"
                        className="w-12rem"
                        value={photo}
                        onChange={(e) => setPhoto(e.target.value)}
                    />
                </div>
            </Dialog>
        </div>
    )
};

export default SignUp;