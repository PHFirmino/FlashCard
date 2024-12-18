import {
    AlertDialog,
    AlertDialogAction,
    AlertDialogCancel,
    AlertDialogContent,
    AlertDialogDescription,
    AlertDialogFooter,
    AlertDialogHeader,
    AlertDialogTitle,
    AlertDialogTrigger,
} from "@/components/ui/alert-dialog"

import { Button } from "@/components/ui/button"
import { useState } from "react"

import { Toaster, toast } from "sonner";


export default function ExcluirCard(props){

    const [idCard, setIdCard] = useState(props.card.id);

    async function excluir(){
        await fetch(`https://localhost:7158/deletecard/${idCard}`, {
            method : "DELETE",
            headers : {
                "Content-Type" : "application/json",
            }
        })
        .then(response => response.json())
        .then(data => {
            if(data.id){
                toast.success("Card excluído com sucesso!", {
                    duration: 700,
                })
            }
            else{
                toast.error("Erro ao excluir card!", {
                    duration: 700,
                })
            }
        })

        await props.atualizarCards()
    }

    return(
        <>
        <Toaster/>
        <AlertDialog>
            <AlertDialogTrigger>
                <Button>Excluir</Button>
            </AlertDialogTrigger>
            <AlertDialogContent>
                <AlertDialogHeader>
                <AlertDialogTitle>Exluir card</AlertDialogTitle>
                <AlertDialogDescription>
                    Esta ação não pode ser desfeita. Isso excluirá permanentemente seu card.
                </AlertDialogDescription>
                </AlertDialogHeader>
                <AlertDialogFooter>
                <AlertDialogCancel>Cancelar</AlertDialogCancel>
                <AlertDialogAction onClick={excluir}>Confirmar</AlertDialogAction>
                </AlertDialogFooter>
            </AlertDialogContent>
        </AlertDialog>
        </>
    )
}