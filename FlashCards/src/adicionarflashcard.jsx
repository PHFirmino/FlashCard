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

export default function AdicionarFlashCard(props){

    const [cards, setCards] = useState([])
    const [cardsIds, setCardsIds] = useState([])
    const [flashs, setFlashs] = useState([])

    const [flashsId, setFlashsId] = useState()
    const [nome, setNome] = useState("")

    useEffect(() => {
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


    async function adicionar(){

        let cardsEnviar = []

        cardsIds.forEach((item) => {
            cardsEnviar.push(item.value)
        } )
        
        await fetch("https://localhost:7158/addflashcard", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
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
                toast.success("Flashcard adicionado com sucesso!", {
                    duration: 700,
                })
            }
            else{
                toast.error("Erro ao adicionar flashcard", {
                    duration: 700,
                })
            }
        })

        setCards([])
        setCardsIds([])
        setFlashs([])
        setFlashsId()
        setNome("")

        await props.atualizarFlashCards()
    }

    return (
        <>
            <Toaster/>
            <Dialog>
                <div class="w-32">
                    <DialogTrigger asChild>
                        <Button>Adicionar</Button>
                    </DialogTrigger>
                </div>
                <DialogContent className="sm:max-w-[425px]">
                    <DialogHeader>
                    <DialogTitle>Adicionar flashCard</DialogTitle>
                    <DialogDescription>
                        Adicione seu flashCard aqui. Clique em salvar quando terminar.
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
                    <Button onClick={adicionar}>Adicionar</Button>
                    </DialogFooter>
                </DialogContent>
            </Dialog>
        </>
    )
}