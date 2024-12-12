fun main() {
    val input = readInput("input")[0]
    val defragmented = mutableListOf<Int>()
    var fileIndex = 0

    for (i in 0..input.lastIndex) {
        val nr: Int = input[i] - '0'

        if (i % 2 == 0) { // paran - fajl, neparan - prazno
            for (j in 1..nr) {
                defragmented.add(fileIndex)
            }
            fileIndex++
        }
        else {
            for (j in 1..nr) {
                defragmented.add(-1)
            }
        }
    }

    var leftIndex = 0
    while (defragmented[leftIndex] != -1) leftIndex++
    var rightIndex = defragmented.lastIndex
    while (defragmented[rightIndex] == -1) rightIndex--

    while (leftIndex < rightIndex) {
        val tmp = defragmented[leftIndex]
        defragmented[leftIndex] = defragmented[rightIndex]
        defragmented[rightIndex] = tmp

        while (defragmented[leftIndex] != -1) leftIndex++
        while (defragmented[rightIndex] == -1) rightIndex--
    }

    var checksum: Long = 0
    var i = 0
    while (defragmented[i] != -1) {
        checksum += defragmented[i] * i
        i++
    }

    println(checksum)
}
