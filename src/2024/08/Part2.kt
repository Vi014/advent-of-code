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

            if (char != '.') {
                for (j1 in j+1..line.lastIndex) {
                    if (input[i][j1] == char) {
                        for (k in 0..line.lastIndex) {
                            if (antinodes[j][k] != '#') {
                                count++
                                antinodes[i][k] = '#'
                            }
                        }
                    }
                }

                for (i1 in i+1..input.lastIndex) {
                    for (j1 in 0..input[i1].lastIndex) {
                        if (input[i1][j1] == char) {
                            if(antinodes[i][j] != '#') {
                                count++
                                antinodes[i][j] = '#'
                            }
                            if(antinodes[i1][j1] != '#') {
                                count++
                                antinodes[i1][j1] = '#'
                            }

                            val distanceI = i1 - i
                            val distanceJ = j1 - j

                            var newI = i1 + distanceI
                            var newJ = j1 + distanceJ

                            while (newI <= input.lastIndex && newJ <= input[i1].lastIndex && newJ >= 0) {
                                if (antinodes[newI][newJ] != '#') {
                                    count++
                                    antinodes[newI][newJ] = '#'
                                }
                                newI += distanceI
                                newJ += distanceJ
                            }

                            newI = i - distanceI
                            newJ = j - distanceJ

                            while (newI >= 0 && newJ <= input[i1].lastIndex && newJ >= 0) {
                                if (antinodes[newI][newJ] != '#') {
                                    count++
                                    antinodes[newI][newJ] = '#'
                                }
                                newI -= distanceI
                                newJ -= distanceJ
                            }
                        }
                    }
                }
            }
        }
    }

    for (line in antinodes) {
        println(line)
    }

    println(count)
}
