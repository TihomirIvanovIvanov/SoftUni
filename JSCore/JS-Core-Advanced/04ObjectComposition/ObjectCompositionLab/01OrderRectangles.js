function orderRectangles(input) {
    function createRectangle(width, height) {
        let rect = {
            width: width,
            height: height,
            area: () => rect.width * rect.height,
            compareTo: function (otherRect) {
                let result = otherRect.area() - rect.area();
                return result || (otherRect.width - rect.width);
            }
        };
        return rect;
    }

    let rects = [];

    for (let [width, height] of input) {
        let rect = createRectangle(width, height);
        rects.push(rect);
    }

    let sortedRects = rects.sort((a, b) => a.compareTo(b));
    return sortedRects;
}

console.log(orderRectangles([[10,5],[5,12]]));