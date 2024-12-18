
import './cards.css'

import AdicionarCard from "./adiconarcard"
import CarregarCards from './carregaCards'
import FiltrarCards from './filtrarcards'
import { useState, useEffect } from 'react'


export default function Cards(){
    
    const [cards, setCards] = useState([])
    const [loading, setLoading] = useState()
    const [search, setSearch] = useState("")

    useEffect(() => {
        carregarCards();

    }, [])

    function carregarCards(){
        setLoading(false)
        fetch("https://localhost:7158/allcards", {
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(response => response.json())
        .then(data => {
            setLoading(true)
            setCards(data)
        })
        .catch(e => 
            setLoading(false)
        )
    }

    function atualizarCards(){
        setSearch("")
        carregarCards()
    }

    return (
        <>
        <div>
            <div class="mt-10 ml-10 mb-10 flex justify-between">
                <FiltrarCards setCards={setCards} atualizarCards={atualizarCards} search={search} setSearch={setSearch}/>
                <AdicionarCard atualizarCards={atualizarCards}/>
            </div>
            {
                loading && cards.length == 0 ? <p className="text-center text-sm font-medium">Sem resultado</p> : <CarregarCards cards={cards} loading={loading} atualizarCards={atualizarCards}/>
            }
        </div>
        </>
    )
}