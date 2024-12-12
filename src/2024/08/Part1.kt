fun main() {
    val input = readInput("input")

    var count = 0
    val antinodes: MutableList<StringBuilder> = mutableListOf()
    for (line in input) {
        antinodes.add(StringBuilder(line))
    }

    for (i in 0..input.lastIndex) {
        val line = input[i]

        for (j in 0..line.lastIndex) {
            val char = line[j]

            if (char != '.' && char != '#') {
                for (j1 in j+1..line.lastIndex) {
                    if (input[i][j1] == char) {
                        val distance = j1 - j
                        if (j1 + distance <= line.lastIndex && antinodes[i][j1+distance] != '#') {
                            count++
                            antinodes[i][j1+distance] = '#'
                        }
                        if (j - distance >= 0 && antinodes[i][j - distance] != '#') {
                            count++
                            antinodes[i][j-distance] = '#'
                        }
                    }
                }

                for (i1 in i+1..input.lastIndex) {
                    for (j1 in 0..input[i1].lastIndex) {
                        if (input[i1][j1] == char ) {
                            val distanceI = i1 - i
                            val distanceJ = j1 - j

                            if (i1 + distanceI <= input.lastIndex
                                && j1 + distanceJ <= input[i1].lastIndex && j1 + distanceJ >= 0
                                && antinodes[i1+distanceI][j1+distanceJ] != '#') {
                                count++
                                antinodes[i1+distanceI][j1+distanceJ] = '#'
                            }

                            if (i - distanceI >= 0
                                && j - distanceJ <= input[i1].lastIndex && j - distanceJ >= 0
                                && antinodes[i-distanceI][j-distanceJ] != '#') {
                                count++
                                antinodes[i-distanceI][j-distanceJ] = '#'
                            }
                        }
                    }
                }
            }
        }
    }

    println(count)
}
