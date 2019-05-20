class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(a, b) {
        let dX = a.x - b.x;
        let dY = a.y - b.y;
        return Math.sqrt(dX * dX + dY * dY);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
