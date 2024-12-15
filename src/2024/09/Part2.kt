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

    var i = defragmented.lastIndex
    while (i >= 0) {
        if (defragmented[i] != -1) {
            var nrLength = 1
            while (i - nrLength >= 0 && defragmented[i - nrLength] == defragmented[i]) nrLength++
            i -= nrLength

            var j = 0
            while (j <= i) {
                if (defragmented[j] == -1) {
                    var freeLength = 1
                    while(defragmented[j + freeLength] == -1) freeLength++
                    if (freeLength >= nrLength) {
                        for (k in 0..nrLength - 1) {
                            defragmented[j + k] = defragmented[i + 1]
                            defragmented[i + nrLength - k] = -1
                        }
                        break
                    }
                    j += freeLength
                }
                else j++
            }
        }
        else i--
    }

    var checksum: Long = 0
    for (i in 0..defragmented.lastIndex) {
        if (defragmented[i] == -1) continue
        checksum += defragmented[i] * i
    }

    println(checksum)
}
