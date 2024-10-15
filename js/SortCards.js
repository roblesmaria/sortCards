
//mapping card to value (card value, sort value) ex (a, 13)
const numSort = {
    '2': 1, '3': 2, '4': 3, '5': 4, '6': 5, '7': 6, '8': 7, '9': 8, '10': 9,
    'J': 10, 'Q': 11, 'K': 12, 'A': 13
};

//suit sort order
const suitSort = ['d', 's', 'c', 'h'];

function sortCards(cardList)
{
    let diamonds = [];
    let spades = [];
    let clubs = [];
    let hearts = [];
    //place each card type into a 
    cardList.forEach(element => {
        if(element.includes('d'))
            diamonds.push(element);
        else if(element.includes('s'))
            spades.push(element);
        else if(element.includes('c'))
            clubs.push(element);
        else if(element.includes('h'))
            hearts.push(element);
        //else 
            //throw invalid suit error
    });

    //sort cards by number and by suit
    //sort individual arrays 
    diamonds.sort(sortRule);
    spades.sort(sortRule);
    clubs.sort(sortRule);
    hearts.sort(sortRule);

    return sortBySuit(diamonds, spades, clubs, hearts);
}

function sortBySuit(diamonds, spades, clubs, hearts)
{
    let sortedCards = [];

    suitSort.forEach(element => {
        if(element === 'd')
            sortedCards = sortedCards.concat(diamonds);
        else if(element === 's')
            sortedCards = sortedCards.concat(spades);
        else if(element === 'c')
            sortedCards = sortedCards.concat(clubs);
        else if(element === 'h')
            sortedCards = sortedCards.concat(hearts);
        //else 
            //throw invalid suit error
    });
    
    return sortedCards;
}

function sortRule(a, b)
{
    let numA = a.slice(0, a.length - 1);
    let numB = b.slice(0, b.length - 1);

    if(numSort[numA] < numSort[numB])
        return -1;
    else if(numSort[numA] > numSort[numB])
        return 1;
    else 
        return 0;
}

const testInput = ['3c', 'Js', '2d', '10h', 'Kh', '8s', 'Ac', '4h'];
sortCards(testInput);