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

import {
    Select,
    SelectContent,
    SelectGroup,
    SelectItem,
    SelectLabel,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"

import { MultiSelect } from "react-multi-select-component"

import { Toaster, toast } from "sonner"

import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { useEffect, useState } from "react"


export default function EditarFlashCard(props){

    const [flashcardId, setFlashcardId] = useState(props.editar.flashCard.id)

    const [cards, setCards] = useState([])
    const [cardsIds, setCardsIds] = useState([props.editar.card])
    const [flashs, setFlashs] = useState([])

    const [flashsId, setFlashsId] = useState(props.editar.flash.id)
    const [nome, setNome] = useState(props.editar.flashCard.nome)


    useEffect(() => {
        let mudarObjetoParaLabelEValueEditado = []

        props.editar.card.forEach(element => {
            mudarObjetoParaLabelEValueEditado.push({
                label: element.pergunta,
                value: element.id
            })
        })

        setCardsIds(mudarObjetoParaLabelEValueEditado)

        fetch("https://localhost:7158/allflashs", {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            }
        })
        .then(response => response.json())
        .then(data => {
            setFlashs(data)
        })

        fetch("https://localhost:7158/allcards", {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            }
        })
        .then(response => response.json())
        .then(data => {

            let mudarObjetoParaLabelEValue = []

            data.forEach(element => {
                mudarObjetoParaLabelEValue.push({
                    label: element.pergunta,
                    value: element.id
                })
            })

            setCards(mudarObjetoParaLabelEValue)
        })
    }, [])

    async function editar(){

        let cardsEnviar = []

        cardsIds.forEach((item) => {
            cardsEnviar.push(item.value)
        } )

        await fetch(`https://localhost:7158/editflashcard/${flashcardId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(               {
                "Nome": nome,
                "Flash": JSON.parse(flashsId),
                "Card" : cardsEnviar
            })
        })
        .then(response => response.json())
        .then(data => {
            if(data.id){
                toast.success("Flashcard editado com sucesso!")
            }
            else{
                toast.error("Erro ao editar flashcard")
            }
        })

        await props.atualizarFlashCards()
    }

    return (
        <>
            <Toaster/>
            <Dialog>
                <div class="w-20 mt-6">
                    <DialogTrigger asChild>
                        <Button>Editar</Button>
                    </DialogTrigger>
                </div>
                <DialogContent className="sm:max-w-[425px]">
                    <DialogHeader>
                    <DialogTitle>Editar flashCard</DialogTitle>
                    <DialogDescription>
                        Edite seu flashCard aqui. Clique em salvar quando terminar.
                    </DialogDescription>
                    </DialogHeader>
                    <div className="grid gap-4 py-4">
                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="nome" className="text-right">
                            Nome
                            </Label>
                            <Input id="nome" className="col-span-3" value={nome} onChange={((e) => setNome(e.target.value))}/>
                        </div>
                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="resposta" className="text-right">
                            Cards
                            </Label>
                            <MultiSelect placeholder="Selecione cards" className="col-span-3 rounded-sm border border-input bg-transparent placeholder:text-muted-foreground focus:outline-none focus:ring-1 focus:ring-ring"  id="tipos" options={cards} value={cardsIds} onChange={(e) => {
                                setCardsIds(e)
                            }} labelledBy="Select"/>
                        </div>
                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="resposta" className="text-right">
                            Flash
                            </Label>
                            <Select onValueChange={setFlashsId} value={flashsId}>
                                <SelectTrigger className="w-[275px]">
                                    <SelectValue placeholder="Selecione Flash" />
                                </SelectTrigger>
                                <SelectContent>
                                    <SelectGroup>
                                    <SelectLabel>Flash</SelectLabel>
                                    {
                                        flashs.map((flash) => {
                                            return (
                                                <SelectItem key={flash.id} value={flash.id}>{flash.nome}</SelectItem>
                                            )
                                        })
                                    }
                                    </SelectGroup>
                                </SelectContent>
                            </Select>
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