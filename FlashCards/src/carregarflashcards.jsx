import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger,
} from "@/components/ui/accordion"

import { Button } from "./components/ui/button";
import ExcluirFlashCard from "./excluirflashcard";
import EditarFlashCard from "./editarflashcard";

import { Link } from "react-router-dom"

export default function CarregarFlashCards(props){
    return (
      <div className="m-5 pl-4">
        <>
          {
            props.flashCards.map((item) => {
              return(
                <>
                <div className="flex">
                  <EditarFlashCard editar={item} atualizarFlashCards={props.atualizarFlashCards} >Editar</EditarFlashCard>
                  <ExcluirFlashCard excluir={item.flashCard} atualizarFlashCards={props.atualizarFlashCards}>Excluir</ExcluirFlashCard>
                  <Link className= "mt-6 ml-3 h-9 px-4 py-2 bg-zinc-900 text-zinc-50 shadow hover:bg-zinc-900/90 dark:bg-zinc-50 dark:text-zinc-900 dark:hover:bg-zinc-50/90 inline-flex items-center justify-center whitespace-nowrap rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-zinc-950 disabled:pointer-events-none disabled:opacity-50 dark:focus-visible:ring-zinc-300" to={"/quiz/" + item.flashCard.id}>
                  Inicar teste</Link>
                </div>
                <Accordion type="single" collapsible key={item.flashCard.id}>
                  <AccordionItem value="item-1">
                    <AccordionTrigger>{item.flashCard.nome}</AccordionTrigger>
                    <AccordionContent>
                      
                    <Accordion type="single" collapsible>
                      <AccordionItem value="item-1">
                        <AccordionTrigger>{item.flash.nome}</AccordionTrigger>
                          {
                            item.card.map((card) => {
                              return(
                                <AccordionContent key={card.id}>
                                  <p>{card.pergunta}</p>
                                  <p>{card.resposta}</p>
                                </AccordionContent>
                              )
                            })
                          }
                      </AccordionItem>
                    </Accordion>
                    </AccordionContent>
                  </AccordionItem>
                </Accordion>
                </>
              )
            })
          }
        </>
      </div>
    );
}