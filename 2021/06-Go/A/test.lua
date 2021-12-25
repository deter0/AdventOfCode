local function readFile(path)
    local file = io.open(path, "rb");
    if (not file) then return nil; end
    local content = file:read("*a");
    file:close();
    return content;
end

local function splitString(str, sep)
    local lines = {};
    for split in string.gmatch(str, "([^" .. sep .. "]+)") do
        lines[#lines + 1] = split;
    end
    return lines;
end

local Data = readFile("./input.txt");
Data = splitString(Data, ",");
for i, v in ipairs(Data) do Data[i] = tonumber(v); end

local fishLen = #Data;
for _ = 1, 24 do
    local fish;
    local total = 0;
    for j = 1, fishLen do
        fish = Data[j];
        total = total + fish;
        io.write(fish .. " ");
        if (fish <= 0) then
            Data[j] = 6;
            Data[fishLen + 1] = 8;
            fishLen = fishLen + 1;
        else
            Data[j] = fish - 1;
        end
    end
    io.write(" = " .. total);
    print();
end
