import axios from "axios";
import { useState } from "react"

interface OptionFields {
    name: string;
    distance: number;
}

interface ExpectedResponse {
    petShop: OptionFields
    price: number
}

export default function FormDogs() {
    const today = new Date(Date.now()).toLocaleDateString();

    const [date, setDate] = useState(today);
    const [numberSmDogs, setNumberSmDogs] = useState(0);
    const [numberLgDogs, setNumberLgDogs] = useState(0);

    const [response, setResponse] = useState<ExpectedResponse>();
    const [error, setError] = useState('');

    const handleSubmit = async () => {
        let queryDate = date.replace(/\//g, "-");
        try {
            const result = await axios.get('https://localhost:7289/api/best-option?date=20-10-2023&smallDogs=1&largeDogs=1');

            setResponse(result.data);
        } catch (error: any) {
            console.log(error);
            setError(error.message)
        }
    }

    return (
        <>
            {response ? 
            <div className="flex flex-col justify-center items-center gap-8">
                <h2 className="text-4xl">Eduardo, encontramos a melhor opção para você</h2>
                <span className="text-2xl info">{response.petShop.name}, Preço: R${response.price} com distância de {response.petShop.distance} km do seu canil</span>
            </div> 
            : 
                <form className="flex flex-col justify-center items-center gap-8">

                    <div className="flex flex-row justify-between gap-8 flex-wrap	">
                    <div className="sm:col-span-2 sm:col-start-1">
                        <label htmlFor="date" className="block text-sm font-medium leading-6">Data do banho</label>
                        <div className="mt-2">
                        <input type="date" name="date" id="date" className="block w-full rounded-md border-0 p-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6" value={date} 
                        onChange={e => setDate(e.target.value)} />
                        </div>
                    </div>

                    <div className="sm:col-span-2">
                        <label htmlFor="smallDogs" className="block text-sm font-medium leading-6">Quantidade de Cachorros Pequenos</label>
                        <div className="mt-2">
                        <input type="number" min={0} name="smallDogs" id="smallDogs" className="block w-full rounded-md border-0 p-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6" 
                        value={numberSmDogs} onChange={e => setNumberSmDogs(e.target.valueAsNumber)}/>
                        </div>
                    </div>

                    <div className="sm:col-span-2">
                        <label htmlFor="largeDogs" className="block text-sm font-medium leading-6">Quantidade de Cachorros Grandes</label>
                        <div className="mt-2">
                        <input type="number" min={0} name="largeDogs" id="largeDogs" className="block w-full rounded-md border-0 p-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6" 
                        value={numberLgDogs} onChange={e => setNumberLgDogs(e.target.valueAsNumber)}
                        />
                        </div>
                    </div>
                    </div>

                    <button type="button" onClick={handleSubmit} className="button">Fazer orçamento</button>

                    {error ?? <span className="error">Ocorreu um erro ao obter o orçamento: {error}</span>}

                </form>
        }
        </>
    )
    
}