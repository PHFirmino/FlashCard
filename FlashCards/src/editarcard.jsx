import { Button } from "@/components/ui/button"
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog"

import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { useEffect, useState } from "react"

import { Toaster, toast } from "sonner";

export default function EditarCard(props){

    const [idCard, setIdCard] = useState(props.card.id)
    const [perguntaCard, setPerguntaCard] = useState(props.card.pergunta)
    const [respostaCard, setRespostaCard] = useState(props.card.resposta)

    async function editar(){
        await fetch(`https://localhost:7158/editcard/${idCard}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            body : JSON.stringify({
                pergunta: perguntaCard,
                resposta: respostaCard
            })
        })
        .then(response => response.json())
        .then(data => {
            if(data.id){
                toast.success("Card editado com sucesso!")
            }
            else{
                toast.error("Erro ao editar card")
            }
        })

        await props.atualizarCards()
    }

    return(
        <>
            <Toaster/>
            <Dialog>
                <DialogTrigger asChild>
                    <Button variant="outline">Editar</Button>
                </DialogTrigger>
                <DialogContent className="sm:max-w-[425px]">
                    <DialogHeader>
                    <DialogTitle>Editar card</DialogTitle>
                    <DialogDescription>
                        Faça alterações em seu card aqui. Clique em salvar quando terminar.
                    </DialogDescription>
                    </DialogHeader>
                    <div className="grid gap-4 py-4">
                    <div className="grid grid-cols-4 items-center gap-4">
                        <Label htmlFor="pergunta" className="text-right">
                        Pergunta
                        </Label>
                        <Input id="pergunta" value={perguntaCard} className="col-span-3" onChange={(e) => setPerguntaCard(e.target.value)}/>
                    </div>
                    <div className="grid grid-cols-4 items-center gap-4">
                        <Label htmlFor="resposta" className="text-right">
                        Resposta
                        </Label>
                        <Input id="resposta" value={respostaCard} className="col-span-3" onChange={(e) => setRespostaCard(e.target.value)}/>
                    </div>
                    </div>
                    <DialogFooter>
                    <Button onClick={editar}>Editar</Button>
                    </DialogFooter>
                </DialogContent>
                </Dialog>
        </>
    )
}