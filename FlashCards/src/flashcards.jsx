import AdicionarFlashCard from "./adicionarflashcard.jsx";
import CarregarFlashCards from "./carregarflashcards";
import FiltrarFlashCards from "./filtrarflashcards";

import { useState, useEffect } from "react";

export default function FlashCards(){

    const [flashCards, setFlashCards] = useState([])
    const [flashCardSearch, setFlashCardSearch] = useState("")
    const [loading, setLoading] = useState()

    useEffect(() => {
        carregarFlashCards()
    }, [])

    async function carregarFlashCards(){
        setLoading(false)
        await fetch("https://localhost:7158/alltestes", {
            method: "GET",
            headers: {
                "Content-Type" : "application/json",
            }
        })
        .then(response => response.json())
        .then(data => {
            setLoading(true)
            setFlashCards(data)
        })
        .catch(e => {
            setLoading(false)
        })
    }

    function atualizarFlashCards(){
        setFlashCardSearch("")
        carregarFlashCards()
    }

    return(
        <>
            <div>
                <div class="mt-10 ml-10 mb-10 flex justify-between">
                    <FiltrarFlashCards setFlashCards={setFlashCards} flashCardSearch={flashCardSearch} setFlashCardSearch={setFlashCardSearch} atualizarFlashCards={atualizarFlashCards}/>
                    <AdicionarFlashCard atualizarFlashCards={atualizarFlashCards}/>
                </div>
            </div>
            {
                loading && flashCards.length == 0 ? <p className="text-center text-sm font-medium">Sem resultado</p> : <CarregarFlashCards flashCards={flashCards} loading={loading} atualizarFlashCards={atualizarFlashCards}/>
            }
        </>
    )
}