import { Button } from "./components/ui/button"
import { Input } from "./components/ui/input"

export default function FiltrarFlashCards(props){

    function filtrar(){
        
        props.setFlashCards([])

        if(props.flashCardSearch.length > 0){
            fetch(`https://localhost:7158/findbynametestes?name=${props.flashCardSearch}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                }
            })
            .then(response => response.json())
            .then(data =>{
                if(data.length > 0){
                    console.log(data)
                    props.setFlashCards(data)
                }
                else{
                    props.setFlashCards([])
                }
            })
            .catch(e => {
                props.setFlashCards([])
            })
        }
        else{
            props.atualizarFlashCards()
        }
    }
    return(
        <>
            <div class="flex w-72">
                <div className="w-60">
                <Input type="text" value={props.flashCardSearch} placeholder="Digite o flashcard" onChange={(e) => props.setFlashCardSearch(e.target.value)}/>
                </div>
                <div className="ml-2">
                    <Button onClick={filtrar}>OK</Button>
                </div>
            </div>
        </>
    )
}